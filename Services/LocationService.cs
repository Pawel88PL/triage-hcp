using Microsoft.EntityFrameworkCore;
using triage_hcp.Models;
using triage_hcp.Services.Interfaces;

namespace triage_hcp.Services
{
    public class LocationService : ILocationService
    {
        private readonly DbTriageContext _context;
        private readonly ILogger<TriageService> _logger;
        
        private static readonly List<string> AlwaysAvailable = new List<string>
        {
            "Korytarz", "Poczekalnia", "Wituś", "WIT", "Dekontaminacja"
        };


        public LocationService(DbTriageContext context, ILogger<TriageService> logger)
        {
            _context = context;
            _logger = logger;
        }


        public async Task<Location?> GetLocationAsync(int locationId)
        {
            var location = await _context.Locations.FindAsync(locationId);

            if (location == null)
            {
                _logger.LogError("Nie znaleziono łóżka o Id: {locationId}", locationId);
            }

            return location;
        }

        public async Task UpdateLocationAsync(Location location)
        {
            _context.Update(location);
            await _context.SaveChangesAsync();
        }

        public async Task<(bool IsSuccess, Exception? Error)> TransferPatientAsync(int patientId, int oldLocationId, int newLocationId)
        {
            try
            {
                var patient = await _context.Patients.FindAsync(patientId);

                if (patient.LocationId != oldLocationId)
                {
                    throw new Exception("Pacjent nie jest w oczekiwanej lokalizacji.");
                }

                var oldLocation = await _context.Locations.FindAsync(oldLocationId);

                var newLocation = await _context.Locations.FindAsync(newLocationId);

                if (newLocation.IsAvailable || AlwaysAvailable.Contains(newLocation.LocationName))
                {
                    patient.LocationId = newLocationId;

                    if (!AlwaysAvailable.Contains(oldLocation.LocationName))
                    {
                        oldLocation.IsAvailable = true;
                    }

                    if (!AlwaysAvailable.Contains(newLocation.LocationName))
                    {
                        newLocation.IsAvailable = false;
                    }

                    await _context.SaveChangesAsync();
                    return (true, null);
                }
                else
                {
                    throw new Exception("Brak dostępnych miejsc w nowej lokalizacji.");
                }
            }
            catch (Exception ex)
            {
                return (false, ex);
            }
        }


    }
}
