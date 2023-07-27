using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using iText.Forms;
using iText.IO.Font;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using Microsoft.AspNetCore.Mvc;
using triage_hcp.Models;
using triage_hcp.Services.Interfaces;

namespace triage_hcp.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IDetailsService _detailsService;

        public DocumentService(IWebHostEnvironment webHostEnvironment, IDetailsService detailsService)
        {
            _webHostEnvironment = webHostEnvironment;
            _detailsService = detailsService;
        }

        public async Task<byte[]> GeneratePatientDocumentAsync(int PatientId)
        {

            var patient = await _detailsService.GetPatientAsync(PatientId);
            string fullName = string.Concat(patient?.Surname, " ", patient?.Name);
            string templatePath = Path.Combine(_webHostEnvironment.WebRootPath, "docs", "template.pdf");
            string outputPath = Path.Combine(_webHostEnvironment.WebRootPath, "docs", "files", $"{PatientId}.docx");
            string fontPath = Path.Combine(_webHostEnvironment.WebRootPath, "fonts", "Lato-Regular.ttf");

            PdfDocument pdfDoc = new PdfDocument(new PdfReader(templatePath), new PdfWriter(outputPath));
            PdfAcroForm form = PdfAcroForm.GetAcroForm(pdfDoc, true);
            PdfFont font = PdfFontFactory.CreateFont(fontPath, PdfEncodings.IDENTITY_H);

            form.SetGenerateAppearance(false);

            // Page 1
            if (patient?.Color == "red")
            {
                form.GetField("color").SetValue("CZERWONY", font, 9f);
            }
            else if (patient?.Color == "orange")
            {
                form.GetField("color").SetValue("POMARAŃCZOWY", font, 9f);
            }
            else if (patient?.Color == "yellow")
            {
                form.GetField("color").SetValue("ŻÓŁTY", font, 9f);
            }
            else if (patient?.Color == "lightgreen")
            {
                form.GetField("color").SetValue("ZIELONY", font, 9f);
            }
            else
            {
                form.GetField("color").SetValue("NIEBIESKI", font, 9f);
            }

            form.GetField("name").SetValue(fullName, font, 9f);
            form.GetField("pesel").SetValue(patient?.Pesel, font, 9f);
            form.GetField("allergies").SetValue(patient?.Allergies, font, 9f);
            form.GetField("datetime").SetValue(patient?.StartTime.ToString("g"), font, 9f);
            form.GetField("toWhom").SetValue(patient?.ToWhomThePatient, font, 9f);
            form.GetField("location").SetValue(patient?.Location?.LocationName, font, 9f);
            form.GetField("symptoms").SetValue(patient?.Symptoms, font, 9f);
            form.GetField("time").SetValue(patient?.StartTime.ToString("t"), font, 9f);
            form.GetField("sbp").SetValue(patient?.SBP.ToString(), font, 9f);
            form.GetField("dbp").SetValue(patient?.DBP.ToString(), font, 9f);
            form.GetField("heartRate").SetValue(patient?.HeartRate.ToString(), font, 9f);
            form.GetField("o2").SetValue(patient?.Spo2.ToString(), font, 9f);
            form.GetField("gcs").SetValue(patient?.GCS.ToString(), font, 9f);
            form.GetField("temp").SetValue(patient?.BodyTemperature.ToString(), font, 9f);

            // Page 2
            form.GetField("name2").SetValue(fullName, font, 9f);
            form.GetField("pesel2").SetValue(patient?.Pesel, font, 9f);
            form.GetField("allergies2").SetValue(patient?.Allergies, font, 9f);
            form.GetField("symptoms2").SetValue(patient?.Symptoms, font, 9f);
            form.GetField("datetime2").SetValue(patient?.StartTime.ToString("g"), font, 9f);
            form.GetField("location2").SetValue(patient?.Location?.LocationName, font, 9f);
            form.GetField("age").SetValue(patient?.Age, font, 9f);

            // Page 3
            form.GetField("name3").SetValue(fullName, font, 9f);
            form.GetField("pesel3").SetValue(patient?.Pesel, font, 9f);

            // Page 4
            form.GetField("name4").SetValue(fullName, font, 9f);
            form.GetField("pesel4").SetValue(patient?.Pesel, font, 9f);

            // Page 5
            form.GetField("name5").SetValue(fullName, font, 9f);
            form.GetField("pesel5").SetValue(patient?.Pesel, font, 9f);

            form.FlattenFields();
            pdfDoc.Close();

            return await File.ReadAllBytesAsync(outputPath);
        }
    }
}