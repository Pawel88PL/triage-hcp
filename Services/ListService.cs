using Microsoft.EntityFrameworkCore;
using triage_hcp.Models;
using triage_hcp.Services.Interfaces;

namespace triage_hcp.Services
{
    public class ListService: IListService
    {
        private readonly DbTriageContext _context;

        public ListService(DbTriageContext context)
        {
            _context = context;
        }

        public async Task<List<Patient>> GetAllAsync()
        {
            var pacjenci = await _context.Pacjenci.ToListAsync();

            return pacjenci;
        }
    }
}
