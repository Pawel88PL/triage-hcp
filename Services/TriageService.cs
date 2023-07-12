using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using triage_hcp.Models;
using triage_hcp.Services.Interfaces;

namespace triage_hcp.Services
{
    public class TriageService : ITriageService
    {
        private readonly DbTriageContext _context;
        private readonly ILogger<TriageService> _logger;

        public TriageService(DbTriageContext context, ILogger<TriageService> logger)
        {
            _context = context;
            _logger = logger;
        }


        public async Task<int> SaveAsync(Pacjent pacjent)
        {
            await _context.Pacjenci.AddAsync(pacjent);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Wprowadzono kolejnego pacjenta o Id: {Id}", pacjent.Id);

            return pacjent.Id;
        }

        public void SetDefaultPatientFields(Pacjent pacjent)
        {
            pacjent.DateTime = DateTime.Now;
            pacjent.TriageDate = DateTime.Today;
            pacjent.Doctor = "Wybierz lekarza";
            pacjent.Active = "Tak";
            pacjent.CoDalejZPacjentem = "W trakcie diagnostyki SOR";
        }

    }
}
