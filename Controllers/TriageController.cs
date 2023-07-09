using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using triage_hcp.Models;
using triage_hcp.Services.Interfaces;

namespace triage_hcp.Controllers
{
    [Authorize]
    public class TriageController : Controller
    {
        private readonly ITriageService _triageService;
        private readonly IDocumentService _documentService;

        public TriageController(ITriageService triageService, IDocumentService documentService)
        {
            _triageService = triageService;
            _documentService = documentService;
        }


        [HttpGet]
        public IActionResult AddNewPatient()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddNewPatient(Pacjent pacjent)
        {
            if (!ModelState.IsValid)
            {
                return View(pacjent);
            }

            var now = DateTime.Now;
            var today = DateTime.Today;

            pacjent.DateTime = now;
            pacjent.TriageDate = today;

            var Id = await _triageService.SaveAsync(pacjent);

            var fileBytes = await _documentService.GeneratePatientDocumentAsync(Id);
            var fileName = $"{Id}.docx";

            Response.Headers.Add("Content-Disposition", $"attachment; filename={fileName}");

            return File(fileBytes, "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
        }

        [HttpGet]
        public async Task<IActionResult> GeneratePatientDocument(int Id)
        {
            var fileBytes = await _documentService.GeneratePatientDocumentAsync(Id);
            var fileName = $"{Id}.docx";

            Response.Headers.Add("Content-Disposition", $"attachment; filename={fileName}");

            return File(fileBytes, "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
        }

    }
}
