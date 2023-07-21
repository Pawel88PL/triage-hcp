using triage_hcp.Models;

namespace triage_hcp.Services.Interfaces
{
    public interface IPeselService
    {
        bool IsPeselCorrect(string pesel);

        string CalculateAge(string pesel);

        string DetermineGender(string pesel);

        void SetAgeAndGender(Patient pacjent);
    }
}
