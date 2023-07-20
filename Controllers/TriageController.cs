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

        // Pobranie widoku formularza Triage.
        [HttpGet]
        public async Task<IActionResult> AddNewPatient()
        {
            await SetViewBagLocations();
            return View();
        }


        // Akcja dodająca nowego pacjenta do systemu.
        [HttpPost]
        public async Task<IActionResult> AddNewPatient(Patient pacjent)
        {
            // Sprawdzenie czy wprowadzone dane są poprawne.
            if (!ModelState.IsValid)
            {
                await SetViewBagLocations();
                return View(pacjent);
            }

            // Zapisanie w bazie danych informacji o płci i wieku z numeru PESEL.
            _peselService.SetAgeAndGender(pacjent);

            // Deklaracja domyślnych pól dla nowego pacjenta
            _triageService.SetDefaultPatientFields(pacjent);

            // Zapisanie nowego rekordu (pacjenta) w bazie danych
            var Id = await _triageService.AddNewPatientAsync(pacjent);

            // Wygenerowanie pliku IdPacjenta.docx z dokumentacją do druku
            var fileBytes = await _documentService.GeneratePatientDocumentAsync(Id);
            var fileName = $"{Id}.docx";
            Response.Headers.Add("Content-Disposition", $"attachment; filename={fileName}");
            return File(fileBytes, "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
        }

    }
}
