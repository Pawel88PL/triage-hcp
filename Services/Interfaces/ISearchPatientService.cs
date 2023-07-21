using triage_hcp.Models;

namespace triage_hcp.Services.Interfaces
{
    public interface ISearchPatientService
    {
        Task<IEnumerable<Patient>> SearchPatientsAsync(string searchTerm);
    }
}
