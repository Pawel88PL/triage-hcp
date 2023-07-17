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
            var patient = await _context.Patients.FindAsync(patientId);

            if (patient == null)
            {
                _logger.LogError($"Nie znaleziono pacjenta o Id: {patientId}", patientId);
            }

            return patient;
        }

        public async Task<Location?> GetLocationAsync(int locationId)
        {
            var location = await _context.Locations.FindAsync(locationId);

            if (location == null)
            {
                _logger.LogError($"Nie znaleziono łóżka o Id: {locationId}", locationId);
            }

            return location;
        }

        public async Task UpdatePatientAsync(Patient patient)
        {
            _context.Update(patient);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateLocationAsync(Location location)
        {
            _context.Update(location);
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
