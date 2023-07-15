using triage_hcp.Models;

namespace triage_hcp.Services.Interfaces
{
    public interface IDetailsService
    {
        Task<Patient?> GetAsync(int Id);

        Task UpdatePacjentAsync(Patient pacjent);

        decimal CalculateTotalPatientTime(DateTime startTime, DateTime endTime);

    }
}
