using triage_hcp.Models;

namespace triage_hcp.Services.Interfaces
{
    public interface IDetailsService
    {
        Task<Patient?> GetPatientAsync(int patientId);
        Task<Location?> GetLocationAsync(int locationId);

        Task UpdatePatientAsync(Patient patient);
        Task UpdateLocationAsync(Location location);

        decimal CalculateTotalPatientTime(DateTime startTime, DateTime endTime);

    }
}
