using triage_hcp.Models;

namespace triage_hcp.Services.Interfaces
{
    public interface IDetailsService
    {
        Task<Patient?> GetPatientAsync(int patientId);

        Task<(bool IsSuccess, Exception? Error)> UpdatePatientAsync(Patient patient);
    }
}
