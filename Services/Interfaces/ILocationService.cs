using triage_hcp.Models;

namespace triage_hcp.Services.Interfaces
{
    public interface ILocationService
    {
        Task<Location?> GetLocationAsync(int locationId);
        
        Task UpdateLocationAsync(Location location);

        Task<(bool IsSuccess, Exception? Error)> TransferPatientAsync(int patientId, int oldLocationId, int newLocationId);
    }
}
