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

            Patient patient = await _detailsService.GetPatientAsync(PatientId);

            string templatePath = Path.Combine(_webHostEnvironment.WebRootPath, "docs", "template.pdf");
            string outputPath = Path.Combine(_webHostEnvironment.WebRootPath, "docs", "files", $"{PatientId}.docx");

            PdfDocument pdfDoc = new PdfDocument(new PdfReader(templatePath), new PdfWriter(outputPath));
            PdfAcroForm form = PdfAcroForm.GetAcroForm(pdfDoc, true);

            // Being set as true, this parameter is responsible to generate an appearance Stream
            // while flattening for all form fields that don't have one. Generating appearances will
            // slow down form flattening, but otherwise Acrobat might render the pdf on its own rules.
            form.SetGenerateAppearance(true);

            form.GetField("surname").SetValue(patient?.Surname);
            form.GetField("name").SetValue(patient?.Name);

            pdfDoc.Close();

            return await System.IO.File.ReadAllBytesAsync(outputPath);


        }


    }
}