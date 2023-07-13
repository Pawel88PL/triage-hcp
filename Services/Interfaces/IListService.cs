using triage_hcp.Models;

namespace triage_hcp.Services.Interfaces
{
    public interface IListService
    {
        Task<List<Pacjent>> GetAllAsync();
    }
}
