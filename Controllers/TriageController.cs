using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using triage_hcp.Models;
using triage_hcp.Services;
using triage_hcp.Services.Interfaces;

namespace triage_hcp.Controllers
{
    [Authorize]
    public class TriageController : Controller
    {
        private readonly ITriageService _triageService;
        private readonly IPeselService _peselService;
        private readonly IDocumentService _documentService;
        private readonly IListService _listService;
        private readonly ILocationService _locationService;

        
        // Wstrzykiwanie zależności.
        public TriageController(ITriageService triageService, IPeselService peselService,
            IDocumentService documentService, IListService listService, ILocationService locationService)
        {
            _triageService = triageService;
            _peselService = peselService;
            _documentService = documentService;
            _listService = listService;
            _locationService = locationService;
        }


        private async Task SetViewBagLocations()
        {
            var locations = await _listService.GetAvailableLocationsAsync();
            ViewBag.Locations = new SelectList(locations, "LocationId", "LocationName");
            ViewBag.AvailableLocations = await _listService.GetAllLocationsAsync();
        }

        [HttpGet]
        public async Task<IActionResult> AddNewPatient()
        {
            await SetViewBagLocations();
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddNewPatient(Patient pacjent)
        {
            if (!ModelState.IsValid)
            {
                await SetViewBagLocations();
                return View(pacjent);
            }

            _peselService.SetAgeAndGender(pacjent);

            _triageService.SetDefaultPatientFields(pacjent);

            var Id = await _triageService.AddNewPatientAsync(pacjent);

            return RedirectToAction("WithoutDoctor", "Details", new { id = Id });
        }

    }
}
