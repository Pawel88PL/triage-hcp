using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using triage_hcp.Models;
using triage_hcp.Services.Interfaces;

namespace triage_hcp.Services
{
    public class TriageService : ITriageService
    {
        private readonly DbTriageContext _context;
        private readonly ILogger<TriageService> _logger;

        public TriageService(DbTriageContext context, ILogger<TriageService> logger)
        {
            _context = context;
            _logger = logger;
        }


        public async Task<int> SaveAsync(Patient patient)
        {
            await _context.Patients.AddAsync(patient);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Wprowadzono kolejnego pacjenta o Id: {Id}", patient.PatientId);

            return patient.PatientId;
        }

        public void SetDefaultPatientFields(Patient pacjent)
        {
            pacjent.StartTime = DateTime.Now;
            pacjent.DoctorId = 0;
            pacjent.IsActive = true;
            pacjent.WhatNext = "W trakcie diagnostyki SOR";
        }

    }
}
