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

        public async Task<int> DeleteAsync(int Id)
        {
            var pacjent = await _context.Pacjenci.FindAsync(Id);
            _context.Pacjenci.Remove(pacjent);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Usunięto pacjenta o Id: {Id}", Id);

            return Id;
        }

        public async Task<Pacjent> GetAsync(int Id)
        {
            var pacjent = await _context.Pacjenci.FindAsync(Id);

            return pacjent;
        }

        public async Task<List<Pacjent>> GetAllAsync()
        {
            var pacjenci = await _context.Pacjenci.ToListAsync();

            return pacjenci;
        }

        public async Task<int> SaveAsync(Pacjent pacjent)
        {
            // logika zapisująca do bazy
            await _context.Pacjenci.AddAsync(pacjent);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Wprowadzono kolejnego pacjenta o Id: {Id}", pacjent.Id);

            return pacjent.Id;
        }
    }
}
