using Microsoft.EntityFrameworkCore;
using triage_hcp.Models;
using triage_hcp.Services.Interfaces;

namespace triage_hcp.Services
{
    public class DetailsService: IDetailsService
    {
        private readonly DbTriageContext _context;
        private readonly ILogger<TriageService> _logger;

        public DetailsService(DbTriageContext context, ILogger<TriageService> logger)
        {
            _context = context;
            _logger = logger;
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

        public async Task UpdatePatientAsync(Patient patient)
        {
            _context.Update(patient);
            await _context.SaveChangesAsync();
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
