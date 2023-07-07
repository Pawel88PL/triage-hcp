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
        public IActionResult Triage(Pacjent pacjent)
        {
            if (!ModelState.IsValid)
            {
                return View(pacjent);
            }

            var now = DateTime.Now;
            var today = DateTime.Today;

            pacjent.DateTime = now;
            pacjent.TriageDate = today;

            var Id = _triageService.Save(pacjent);

            GeneratePatientDocument(Id);

            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "docs", "files", $"{Id}.docx");

            return PhysicalFile(filePath, "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
        }


        public IActionResult GeneratePatientDocument(int Id)
        {
            
            Pacjent pacjent = _triageService.Get(Id);

            string templatePath = Path.Combine(_webHostEnvironment.WebRootPath, "docs", "Documents.docx");
            string outputPath = Path.Combine(_webHostEnvironment.WebRootPath, "docs", "files", $"{Id}.docx");

            
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
                { "sbp", pacjent.SBP },
                { "dbp", pacjent.DBP },
                { "hrr", pacjent.HeartRate },
                { "spo2", pacjent.Spo2 },
                { "gccs", pacjent.GCS },
                { "temp", pacjent.BodyTemperature },
                
            };

            ReplaceKeywordsInDocx(templatePath, outputPath, keywordData);

            SetDocumentAsReadOnly(outputPath);

            var fileBytes = System.IO.File.ReadAllBytes(outputPath);
            var fileName = $"{Id}.docx";
            
            Response.Headers.Add("Content-Disposition", $"attachment; filename={fileName}");
            
            return File(fileBytes, "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
        }


        public void ReplaceKeywordsInDocx(string templatePath, string outputPath, Dictionary<string, string> keywordData)
        {

            System.IO.File.Copy(templatePath, outputPath, true);

            using (WordprocessingDocument doc = WordprocessingDocument.Open(outputPath, true))
            {
                
                MainDocumentPart mainPart = doc.MainDocumentPart;

                
                foreach (var paragraph in mainPart.Document.Body.Descendants<Paragraph>())
                {
                    foreach (var run in paragraph.Elements<Run>())
                    {
                        foreach (var text in run.Elements<Text>())
                        {
                            foreach (var keyword in keywordData)
                            {
                                if (text.Text.Contains(keyword.Key))
                                {
                                    text.Text = text.Text.Replace(keyword.Key, keyword.Value);
                                }
                            }
                        }
                    }
                }

                mainPart.Document.Save();
            }
        }

        public void SetDocumentAsReadOnly(string docxFilePath)
        {
            using (WordprocessingDocument doc = WordprocessingDocument.Open(docxFilePath, true))
            {
                DocumentSettingsPart settingsPart = doc.MainDocumentPart.GetPartsOfType<DocumentSettingsPart>().FirstOrDefault();
                if (settingsPart == null)
                {
                    settingsPart = doc.MainDocumentPart.AddNewPart<DocumentSettingsPart>();
                    settingsPart.Settings = new Settings();
                }

                DocumentProtection documentProtection = new DocumentProtection()
                {
                    Edit = DocumentProtectionValues.ReadOnly,
                    Enforcement = true,
                };

                settingsPart.Settings.AppendChild(documentProtection);
                settingsPart.Settings.Save();
            }
        }
    }
}
