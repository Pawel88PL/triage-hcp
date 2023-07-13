using triage_hcp.Models;

namespace triage_hcp.Services.Interfaces
{
    public interface IDetailsService
    {
        Task<Pacjent?> GetAsync(int Id);

        Task UpdatePacjentAsync(Pacjent pacjent);

        decimal CalculateTotalPatientTime(DateTime startTime, DateTime endTime);

    }
}
