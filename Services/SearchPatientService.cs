using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using triage_hcp;
using triage_hcp.Models;
using triage_hcp.Services.Interfaces;

public class SearchPatientService : ISearchPatientService
{
    private readonly DbTriageContext _context;

    public SearchPatientService(DbTriageContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Pacjent>> SearchPatientsAsync(string query)
    {
        if (string.IsNullOrEmpty(query))
        {
            return new List<Pacjent>();
        }

        return await _context.Pacjenci
            .Where(p =>
            (p.Name != null && p.Name.Contains(query)) ||
            (p.Surname != null && p.Surname.Contains(query)) ||
            (p.Diagnosis != null && p.Diagnosis.Contains(query)))
        .ToListAsync();
    }
}
