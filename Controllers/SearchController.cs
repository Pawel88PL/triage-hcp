using Microsoft.AspNetCore.Mvc;
using triage_hcp.Services.Interfaces;

public class SearchController : Controller
{
    private readonly ISearchPatientService _searchPatientService;

    public SearchController(ISearchPatientService searchPatientService)
    {
        _searchPatientService = searchPatientService;
    }

    [HttpGet]
    [HttpGet]
    public async Task<IActionResult> SearchPatients(string query)
    {
        var results = await _searchPatientService.SearchPatientsAsync(query);
        var model = new PatientSearchViewModel
        {
            Query = query,
            Patients = results,
        };
        return View(model);
    }

}
