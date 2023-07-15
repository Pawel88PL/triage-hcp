using triage_hcp.Models;

namespace triage_hcp.Services.Interfaces
{
    public interface ITriageService
    {
                
        Task<int> SaveAsync(Patient pacjent);

        void SetDefaultPatientFields(Patient pacjent);
    }
}
