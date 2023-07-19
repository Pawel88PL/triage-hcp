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
            var patients = await _context.Patients
                .Include(p => p.Location)
                .Include(p => p.Doctor)
                .ToListAsync();

            return patients;
        }


        public async Task<List<Doctor>> GetAllDoctorsAsync()
        {
            var doctors = await _context.Doctors.ToListAsync();

            return doctors;
        }
    }
}
