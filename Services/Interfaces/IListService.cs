using triage_hcp.Models;

namespace triage_hcp.Services.Interfaces
{
    public interface IListService
    {
        Task<List<Patient>> GetAllPatientsAsync();

        Task<List<Doctor>> GetAllDoctorsAsync();

        Task<List<Location>> GetAllLocationsAsync();

        Task<List<Location>> GetAvailableLocationsAsync();
    }
}
