using Microsoft.EntityFrameworkCore;
using System.Data;
using triage_hcp.Models;
using triage_hcp.Services.Interfaces;

namespace triage_hcp.Services
{
    public class DetailsService: IDetailsService
    {
        private readonly DbTriageContext _context;
        private readonly ILogger<TriageService> _logger;
        private readonly ILocationService _locationService;

        public DetailsService(DbTriageContext context, ILogger<TriageService> logger, ILocationService locationService)
        {
            _context = context;
            _logger = logger;
            _locationService = locationService;
        }

        public async Task<Patient?> GetPatientAsync(int patientId)
        {
            var patient = await _context.Patients
                    .Include(p => p.Doctor)
                    .Include(p => p.Location)
                    .FirstOrDefaultAsync(p => p.PatientId == patientId);

            if (patient == null)
            {
                _logger.LogError($"Nie znaleziono pacjenta o Id: {patientId}", patientId);
            }

            return patient;
        }

        public async Task<(bool IsSuccess, Exception? Error)> UpdatePatientAsync(Patient patient)
        {
            try
            {
                patient.EndTime = DateTime.Now;
                patient.TotalTime = CalculateTotalPatientTime(patient.StartTime, patient.EndTime);
                _context.Update(patient);
                await _context.SaveChangesAsync();

                if (!patient.IsActive)
                {
                    var location = await _locationService.GetLocationAsync(patient.LocationId);
                    location.IsAvailable = true;
                    await _locationService.UpdateLocationAsync(location);
                }

                return (true, null);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await GetPatientAsync(patient.PatientId) == null)
                {
                    return (false, new InvalidOperationException($"Nie znaleziono pacjenta o Id: {patient.PatientId}"));
                }
                else
                {
                    return (false, new ArgumentException("Nie można zaktualizować danych pacjenta, ponieważ zostały one zmienione przez innego użytkownika. Odśwież stronę i spróbuj ponownie."));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Wystąpił błąd podczas aktualizacji danych pacjenta o Id: {Id}", patient.PatientId);
                return (false, ex);
            }
        }

        public decimal CalculateTotalPatientTime(DateTime startTime, DateTime endTime)
        {
            TimeSpan totalTime = endTime - startTime;
            double totalHours = totalTime.TotalHours;
            decimal totalPatientTime = Math.Round(Convert.ToDecimal(totalHours), 2);
            return totalPatientTime;
        }

    }
}
