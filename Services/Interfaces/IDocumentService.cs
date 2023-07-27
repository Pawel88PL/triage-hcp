namespace triage_hcp.Services.Interfaces
{
    public interface IDocumentService
    {
        Task <byte[]> GeneratePatientDocumentAsync(int Id);
        
    }

}
