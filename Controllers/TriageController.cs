using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using triage_hcp.Models;
using triage_hcp.Services;
using triage_hcp.Services.Interfaces;
using System.IO;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Routing.Template;


namespace triage_hcp.Controllers
{
    [Authorize]
    public class TriageController : Controller
    {
        private readonly ITriageService _triageService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public TriageController(ITriageService triageService, IWebHostEnvironment webHostEnvironment)
        {
            _triageService = triageService;
            _webHostEnvironment = webHostEnvironment;
        }


        [HttpGet]
        public IActionResult Triage()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Triage(Pacjent body)
        {
            if (!ModelState.IsValid)
            {
                return View(body);
            }

            var Id = _triageService.Save(body);

            GeneratePatientDocument(Id);
            return RedirectToAction("List", "Pacjent");
        }


        public void GeneratePatientDocument(int Id)
        {
            // Pobierz dane pacjenta na podstawie ID
            Pacjent pacjent = _triageService.Get(Id);

            string templatePath = Path.Combine(_webHostEnvironment.WebRootPath, "docs", "Documents.docx");
            
            string outputPath = Path.Combine(_webHostEnvironment.WebRootPath, "docs", "files", $"{Id}.docx");
           

            // Słownik słów kluczowych i ich wartości do zastąpienia
            Dictionary<string, string> keywordData = new Dictionary<string, string>
            {
                { "@name", pacjent.Name.ToUpper() },
                { "@sur", pacjent.Surname.ToUpper() },
                { "towhom", pacjent.ToWhomThePatient.ToUpper() },
                { "pesel", pacjent.Pesel },
                { "date", pacjent.DateTime.ToString("g") },
                { "diagnosis", pacjent.Diagnosis.ToUpper() },
                { "room", pacjent.Room },
                { "color", pacjent.Color },
                { "time", pacjent.DateTime.ToString("t") },
            // Dodaj inne słowa kluczowe i ich wartości
            };


            ReplaceKeywordsInDocx(templatePath, outputPath, keywordData);

        }

        public void ReplaceKeywordsInDocx(string templatePath, string outputPath, Dictionary<string, string> keywordData)
        {

            System.IO.File.Copy(templatePath, outputPath, true);

            using (WordprocessingDocument doc = WordprocessingDocument.Open(outputPath, true))
            {
                // Pobierz główną część dokumentu
                MainDocumentPart mainPart = doc.MainDocumentPart;

                // Przejdź przez akapity w dokumencie
                foreach (var paragraph in mainPart.Document.Body.Descendants<Paragraph>())
                {
                    // Przejdź przez tekst w akapicie
                    foreach (var run in paragraph.Elements<Run>())
                    {
                        foreach (var text in run.Elements<Text>())
                        {
                            // Sprawdź, czy tekst zawiera słowo kluczowe
                            foreach (var keyword in keywordData)
                            {
                                if (text.Text.Contains(keyword.Key))
                                {
                                    // Zastąp słowo kluczowe nową wartością
                                    text.Text = text.Text.Replace(keyword.Key, keyword.Value);
                                }
                            }
                        }
                    }
                }

                // Zapisz zmieniony dokument
                mainPart.Document.Save();
            }
        }
    }
}
