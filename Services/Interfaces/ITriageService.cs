using triage_hcp.Models;

namespace triage_hcp.Services.Interfaces
{
    public interface ITriageService
    {
        Task<List<Location>> GetAvailableLocationsAsync();

        Task<int> AddNewPatientAsync(Patient pacjent);

        void SetDefaultPatientFields(Patient pacjent);
    }
}
