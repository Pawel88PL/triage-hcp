using triage_hcp.Models;
using triage_hcp.Services.Interfaces;

namespace triage_hcp.Services
{
    public class TimeService: ITimeService
    {
        private readonly DbTriageContext _context;

        public TimeService(DbTriageContext context)
        {
            _context = context;
        }

        public int CalculatePatientWaitingTime(DateTime start, DateTime end)
        {
            TimeSpan interval = end - start;
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

        public async Task RegisterDoctorAssignmentAsync(Patient patient)
        {
            var patientInDb = await _context.Patients.FindAsync(patient.PatientId);
            if (patientInDb != null && patientInDb.DoctorId == null && patient.DoctorId != null)
            {
                patientInDb.StartDiagnosis = DateTime.Now;
                await _context.SaveChangesAsync();
            }
        }

    }
}
