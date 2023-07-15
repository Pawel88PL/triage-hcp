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

        public async Task<Patient?> GetAsync(int Id)
        {
            var pacjent = await _context.Pacjenci.FindAsync(Id);

            if (pacjent == null)
            {
                _logger.LogError("Nie znaleziono pacjenta o Id: {Id}", Id);
            }

            return pacjent;
        }

        public async Task UpdatePacjentAsync(Patient pacjent)
        {
            _context.Update(pacjent);
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
