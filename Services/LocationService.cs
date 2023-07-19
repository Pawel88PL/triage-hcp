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
    }
}
