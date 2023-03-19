using triage_hcp.Models;

namespace triage_hcp.Services.Interfaces
{
    public interface ITriageService
    {
        int Save(Pacjent pacjent);
        List<Pacjent> GetAll();
        Pacjent Get(int Id);
        int Delete(int Id);
    }
}
