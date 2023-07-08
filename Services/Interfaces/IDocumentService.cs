namespace triage_hcp.Services.Interfaces
{
    public interface IDocumentService
    {
        byte[] GeneratePatientDocument(int Id);
        void ReplaceKeywordsInDocx(string templatePath, string outputPath, Dictionary<string, string> keywordData);
        void SetDocumentAsReadOnly(string docxFilePath);
    }

}
