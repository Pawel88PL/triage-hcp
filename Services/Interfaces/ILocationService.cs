using triage_hcp.Models;

namespace triage_hcp.Services.Interfaces
{
    public interface ILocationService
    {
        Task<Location?> GetLocationAsync(int locationId);
        
        Task<List<Location>> GetAvailableLocationsAsync();
        
        Task UpdateLocationAsync(Location location);

    }
}
