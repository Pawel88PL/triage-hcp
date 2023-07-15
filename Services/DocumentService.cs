using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc;
using triage_hcp.Models;
using triage_hcp.Services.Interfaces;

namespace triage_hcp.Services
{
    public class DocumentService: IDocumentService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IDetailsService _editService;

        public DocumentService(IWebHostEnvironment webHostEnvironment, IDetailsService editService)
        {
            _webHostEnvironment = webHostEnvironment;
            _editService = editService;
        }

        public async Task <byte[]> GeneratePatientDocumentAsync(int Id)
        {

            Patient pacjent = await _editService.GetAsync(Id);

            string templatePath = Path.Combine(_webHostEnvironment.WebRootPath, "docs", "Documents.docx");
            string outputPath = Path.Combine(_webHostEnvironment.WebRootPath, "docs", "files", $"{Id}.docx");


            Dictionary<string, string> keywordData = new Dictionary<string, string>
            {
                { "@name", (pacjent.Name ?? "").ToUpper() },
                { "@sur", (pacjent.Surname ?? "" ).ToUpper() },
                { "towhom", (pacjent.ToWhomThePatient ?? "").ToUpper() },
                { "pesel", (pacjent.Pesel ?? "") },
                { "date", pacjent.DateTime.ToString("g") },
                { "diagnosis", (pacjent.Diagnosis ?? "").ToUpper() },
                { "room", (pacjent.Room ?? "") },
                { "color", (pacjent.Color ?? "") },
                { "time", pacjent.DateTime.ToString("t") },
                { "sbp", (pacjent.SBP ?? "") },
                { "dbp", (pacjent.DBP ?? "") },
                { "hrr", (pacjent.HeartRate ?? "") },
                { "spo2", (pacjent.Spo2 ?? "") },
                { "gccs", (pacjent.GCS ?? "") },
                { "temp", (pacjent.BodyTemperature ?? "") },

            };

            await Task.Run(() => ReplaceKeywordsInDocx(templatePath, outputPath, keywordData));

            await Task.Run(() => SetDocumentAsReadOnly(outputPath));

            return await System.IO.File.ReadAllBytesAsync(outputPath);

        }

        public void ReplaceKeywordsInDocx(string templatePath, string outputPath, Dictionary<string, string> keywordData)
        {

            System.IO.File.Copy(templatePath, outputPath, true);

            using (WordprocessingDocument doc = WordprocessingDocument.Open(outputPath, true))
            {

                MainDocumentPart? mainPart = doc.MainDocumentPart;


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
