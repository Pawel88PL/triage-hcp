using triage_hcp.Models;

namespace triage_hcp.Services.Interfaces
{
    public interface ITriageService
    {

        Task<int> AddNewPatientAsync(Patient pacjent);

        void SetDefaultPatientFields(Patient pacjent);
    }
}
