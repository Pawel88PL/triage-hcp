using Microsoft.AspNetCore.Mvc;
using triage_hcp.Services.Interfaces;

namespace triage_hcp.Controllers
{
    public class DocumentationController : Controller
    {
        private readonly IDocumentService _documentService;

        public DocumentationController(IDocumentService documentService)
        {
            _documentService = documentService;
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
