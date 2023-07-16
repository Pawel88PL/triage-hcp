using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using triage_hcp.Models;
using triage_hcp.Services.Interfaces;

namespace triage_hcp.Services
{
    public class DeleteService: IDeleteService
    {
        private readonly DbTriageContext _context;
        private readonly ILogger<DeleteService> _logger;

        public DeleteService(DbTriageContext context, ILogger<DeleteService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> DeletePatientAsync(int id)
        {
            var pacjent = await _context.Patients.FindAsync(id);
            if (pacjent == null)
            {
                _logger.LogError("Nie znaleziono pacjenta o Id: {Id}", id);
                return false;
            }

            _context.Patients.Remove(pacjent);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Usunięto pacjenta o Id: {Id}", id);
            return true;
        }
    }
}
