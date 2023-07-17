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
        private readonly IDetailsService _detailsService;

        public DocumentService(IWebHostEnvironment webHostEnvironment, IDetailsService detailsService)
        {
            _webHostEnvironment = webHostEnvironment;
            _detailsService = detailsService;
        }

        public async Task <byte[]> GeneratePatientDocumentAsync(int PatientId)
        {

            Patient patient = await _detailsService.GetPatientAsync(PatientId);

            string templatePath = Path.Combine(_webHostEnvironment.WebRootPath, "docs", "Documents.docx");
            string outputPath = Path.Combine(_webHostEnvironment.WebRootPath, "docs", "files", $"{PatientId}.docx");


            Dictionary<string, string> keywordData = new Dictionary<string, string>
            {
                { "@name", (patient?.Name ?? "").ToUpper() },
                { "@sur", (patient ?.Surname ?? "" ).ToUpper() },
                { "towhom", (patient ?.ToWhomThePatient ?? "").ToUpper() },
                { "pesel", (patient ?.Pesel ?? "") },
                { "date", patient.StartTime.ToString("g") },
                { "diagnosis", (patient ?.Symptoms ?? "").ToUpper() },
                { "room", (patient?.Location?.LocationName ?? "").ToUpper() },
                { "color", (patient?.Color ?? "") },
                { "time", patient.StartTime.ToString("t") },
                { "sbp", (patient?.SBP.ToString() ?? "") },
                { "dbp", (patient?.DBP.ToString() ?? "") },
                { "hrr", (patient?.HeartRate.ToString() ?? "") },
                { "spo2", (patient?.Spo2.ToString()?? "") },
                { "gccs", (patient?.GCS.ToString() ?? "") },
                { "temp", (patient?.BodyTemperature.ToString() ?? "") },

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
