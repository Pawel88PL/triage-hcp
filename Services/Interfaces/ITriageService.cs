using triage_hcp.Models;

namespace triage_hcp.Services.Interfaces
{
    public interface ITriageService
    {
        int Save(Pacjent pacjent);
    }
}
