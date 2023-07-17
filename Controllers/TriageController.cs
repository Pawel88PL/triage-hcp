using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using triage_hcp.Models;
using triage_hcp.Services.Interfaces;

namespace triage_hcp.Controllers
{
    [Authorize]
    public class TriageController : Controller
    {
        private readonly ITriageService _triageService;
        private readonly IPeselService _peselService;
        private readonly IDocumentService _documentService;

        
        // Wstrzykiwanie zależności.
        public TriageController(ITriageService triageService, IPeselService peselService, IDocumentService documentService)
        {
            _triageService = triageService;
            _peselService = peselService;
            _documentService = documentService;
        }

        
        // Pobranie widoku formularza Triage.
        [HttpGet]
        public async Task<IActionResult> AddNewPatient()
        {
            var locations = await _triageService.GetAvailableLocationsAsync();
            ViewBag.Locations = new SelectList(locations, "LocationId", "LocationName");
            return View();
        }





        // Akcja dodająca nowego pacjenta do systemu.
        [HttpPost]
        public async Task<IActionResult> AddNewPatient(Patient pacjent)
        {
            // Sprawdzenie czy wprowadzone dane są poprawne.
            if (!ModelState.IsValid)
            {
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
