using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using triage_hcp.Models;
using triage_hcp.Services.Interfaces;
using System;
using System.Collections.Generic;

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

        public async Task<int> AddNewPatientAsync(Patient patient)
        {
            var selectedLocation = await _context!.Locations!.FindAsync(patient.LocationId);

            if (selectedLocation != null)
            {
                // Lista miejsc, które zawsze są dostępne
                var alwaysAvailable = new List<string> { "Korytarz", "Poczekalnia", "Wituś", "WIT", "Dekontaminacja" };

                if (alwaysAvailable.Contains(selectedLocation!.LocationName!) || selectedLocation.IsAvailable)
                {
                    _context.Add(patient);
                    await _context.SaveChangesAsync();

                    // Jeśli miejsce nie jest na liście alwaysAvailable, ustawiamy je jako niedostępne
                    if (!alwaysAvailable.Contains(selectedLocation!.LocationName!))
                    {
                        selectedLocation.IsAvailable = false;
                        _context.Update(selectedLocation);
                        await _context.SaveChangesAsync();
                    }

                    _logger.LogInformation("Wprowadzono kolejnego pacjenta o Id: {Id}", patient.PatientId);

                    return patient.PatientId;
                }
                else
                {
                    throw new InvalidOperationException("Wybrane miejsce jest już zajęte.");
                }
            }

            throw new InvalidOperationException("Lokalizacja nie została znaleziona.");
        }

        public void SetDefaultPatientFields(Patient pacjent)
        {
            pacjent.StartTime = DateTime.Now;
            pacjent.DoctorId = null;
            pacjent.IsActive = true;
            pacjent.WhatNext = "W trakcie diagnostyki SOR";
        }

    }
}