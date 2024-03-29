﻿using triage_hcp.Models;

namespace triage_hcp.Services.Interfaces
{
    public interface ITimeService
    {
        int CalculatePatientWaitingTime(DateTime startDate, DateTime doctorTakePatientTime);

        decimal CalculateTotalPatientTime(DateTime startTime, DateTime endTime);

        Task RegisterDoctorAssignmentAsync(Patient patient);
    }
}
