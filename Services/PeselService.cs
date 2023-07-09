using triage_hcp.Services.Interfaces;

public class PeselService : IPeselService
{
    public bool IsPeselCorrect(string pesel)
    {
        if (pesel == null || pesel == "") return false;
        if (pesel.Length != 11) return false;

        int[] weights = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3, 1 };

        int total = 0;
        for (int i = 0; i < 11; i++)
        {
            int r = (int)(pesel[i] - '0');
            if (r < 0 || r > 9) return false;
            total += weights[i] * r;
        }

        if (total % 10 == 0) return true;
        else return false;
    }

    public string CalculateAge(string pesel)
    {
        DateTime YearNow = DateTime.Today;

        if (IsPeselCorrect(pesel) == false) return "00";

        int yearNow = YearNow.Year;

        int patientYear = int.Parse(pesel.Substring(0, 2));
        int month = int.Parse(pesel.Substring(2, 2));

        int ageBefore2000 = yearNow - 1900 - patientYear;
        int ageAfter2000 = yearNow - 2000 - patientYear;

        string ageBefore = ageBefore2000.ToString();
        string ageAfter = ageAfter2000.ToString();

        if (month > 12)
        {
            return ageAfter;

        }
        else
        {
            return ageBefore;
        }
    }

    public string DetermineGender(string pesel)
    {
        if (IsPeselCorrect(pesel) == false) return "Nie określono płci";

        int controlNumber = int.Parse(pesel.Substring(9, 1));
        if (controlNumber == 1 || controlNumber == 3 || controlNumber == 5 ||
            controlNumber == 7 || controlNumber == 9)
        {
            return "Mężczyzna";
        }
        else return "Kobieta";
    }
}
