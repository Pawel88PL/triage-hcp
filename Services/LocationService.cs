using Microsoft.EntityFrameworkCore;
using triage_hcp.Models;
using triage_hcp.Services.Interfaces;

namespace triage_hcp.Services
{
    public class LocationService: ILocationService
    {
        private readonly DbTriageContext _context;
        private readonly ILogger<TriageService> _logger;

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

        public async Task<List<Location>> GetAllLocationsAsync()
        {
            var alllocations = await _context.Locations.ToListAsync();

            return alllocations;
        }

        public async Task<List<Location>> GetAvailableLocationsAsync()
        {

            var availableLocations = await _context.Locations
                .Where(l => l.IsAvailable)
                .ToListAsync();

            return availableLocations;
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
                // Pobieramy pacjenta
                var patient = await _context.Patients.FindAsync(patientId);

                // Sprawdzamy, czy pacjent jest aktualnie w prawidłowej lokalizacji
                if (patient.LocationId != oldLocationId)
                {
                    throw new Exception("Pacjent nie jest w oczekiwanej lokalizacji.");
                }

                // Pobieramy aktualną lokalizację pacjenta
                var oldLocation = await _context.Locations.FindAsync(oldLocationId);

                // Pobieramy nową lokalizację
                var newLocation = await _context.Locations.FindAsync(newLocationId);

                // Sprawdzamy, czy jest dostępne miejsce w nowej lokalizacji
                if (newLocation.IsAvailable)
                {
                    // Zmieniamy lokalizację pacjenta na nową
                    patient.LocationId = newLocationId;

                    // Zwalniamy miejsce w poprzedniej lokalizacji
                    oldLocation.IsAvailable = true;

                    // Zajmujemy miejsce w nowej lokalizacji
                    newLocation.IsAvailable = false;

                    // Zapisujemy zmiany
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
