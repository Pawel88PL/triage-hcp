﻿using triage_hcp.Models;

namespace triage_hcp.Services.Interfaces
{
    public interface IDetailsService
    {
        Task<Patient?> GetPatientAsync(int patientId);

        Task UpdatePatientAsync(Patient patient);

        decimal CalculateTotalPatientTime(DateTime startTime, DateTime endTime);

    }
}
