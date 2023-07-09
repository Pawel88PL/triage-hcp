namespace triage_hcp.Services.Interfaces
{
    public interface IDocumentService
    {
        Task <byte[]> GeneratePatientDocumentAsync(int Id);
        void ReplaceKeywordsInDocx(string templatePath, string outputPath, Dictionary<string, string> keywordData);
        void SetDocumentAsReadOnly(string docxFilePath);
    }

}
