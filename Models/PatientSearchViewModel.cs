using triage_hcp.Models;

public class PatientSearchViewModel
{
    public string? Query { get; set; }
    public IEnumerable<Patient>? Patients { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
}
