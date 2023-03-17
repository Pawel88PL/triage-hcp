using triage_hcp.Models;
using triage_hcp.Services.Interfaces;

namespace triage_hcp.Services
{
    public class TriageService : ITriageService
    {
        public int Save(Pacjent pacjent)
        {
            // logika zapisująca do bazy
            return 1;
        }
    }
}
