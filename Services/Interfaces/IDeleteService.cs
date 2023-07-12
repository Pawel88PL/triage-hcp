using System.Threading.Tasks;

namespace triage_hcp.Services.Interfaces
{
    public interface IDeleteService
    {
        Task<bool> DeletePatientAsync(int id);
    }
}
