using triage_hcp.Services.Interfaces;

namespace triage_hcp.Services
{
    public class TimeService: ITimeService
    {
        public int CalculatePatientWaitingTime(DateTime startDate, DateTime doctorTakePatientTime)
        {
            TimeSpan interval = doctorTakePatientTime - startDate;
            double minutes = interval.TotalMinutes;
            return Convert.ToInt32(minutes);
        }


        public decimal CalculateTotalPatientTime(DateTime startTime, DateTime endTime)
        {
            TimeSpan totalTime = endTime - startTime;
            double totalHours = totalTime.TotalHours;
            decimal totalPatientTime = Math.Round(Convert.ToDecimal(totalHours), 2);
            return totalPatientTime;
        }
    }
}
