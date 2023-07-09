using triage_hcp.Models;

namespace triage_hcp.Services.Interfaces
{
    public interface ITriageService
    {
        Task<int> DeleteAsync(int Id);
        Task<Pacjent?> GetAsync(int Id);
        Task<List<Pacjent>> GetAllAsync();
        Task<int> SaveAsync(Pacjent pacjent);
    }
}
