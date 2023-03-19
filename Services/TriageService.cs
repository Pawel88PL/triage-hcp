using triage_hcp.Models;
using triage_hcp.Services.Interfaces;

namespace triage_hcp.Services
{
    public class TriageService : ITriageService
    {
        
        private readonly DbTriageContext _context;

        public TriageService(DbTriageContext context)
        {
            _context = context;
        }

        public List<Pacjent> GetAll()
        {
            var pacjenci = _context.Pacjenci.ToList();

            return pacjenci;
        }

        public int Save(Pacjent pacjent)
        {
            // logika zapisująca do bazy
            _context.Pacjenci.Add(pacjent);

            if (_context.SaveChanges() > 0)
            {
                Console.WriteLine("Wprowadzono kolejnego pacjenta o Id: {0}", pacjent.Id);
            }
            
            return pacjent.Id;
        }
    }
}
