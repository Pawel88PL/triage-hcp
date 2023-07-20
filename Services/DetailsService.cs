using Microsoft.EntityFrameworkCore;
using System.Data;
using triage_hcp.Models;
using triage_hcp.Services.Interfaces;

namespace triage_hcp.Services
{
    public class DetailsService : IDetailsService
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
                var patientInDb = await _context.Patients.FindAsync(patient.PatientId);
                if (patientInDb != null)
                {
                    patientInDb.Color = patient.Color;
                    patientInDb.DoctorId = patient.DoctorId;
                    patientInDb.ToWhomThePatient = patient.ToWhomThePatient;
                    patientInDb.LocationId = patient.LocationId;
                    patientInDb.WhatNext = patient.WhatNext;
                    patientInDb.IsActive = patient.IsActive;
                    patient.EndTime = DateTime.Now;
                    patient.TotalTime = CalculateTotalPatientTime(patient.StartTime, patient.EndTime);

                    if (!patient.IsActive)
                    {
                        var location = await _locationService.GetLocationAsync(patient.LocationId);
                        location.IsAvailable = true;
                        await _locationService.UpdateLocationAsync(location);
                    }

                    await _context.SaveChangesAsync();
                    return (true, null);
                }
                else
                {
                    return (false, new InvalidOperationException($"Nie znaleziono pacjenta o Id: {patient.PatientId}"));
                }
            }
            catch (DbUpdateConcurrencyException)
            {

                return (false, new ArgumentException("Nie można zaktualizować danych pacjenta, ponieważ zostały one zmienione przez innego użytkownika. Odśwież stronę i spróbuj ponownie."));
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
