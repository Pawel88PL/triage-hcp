using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using triage_hcp.Models;
using triage_hcp.Services.Interfaces;

namespace triage_hcp.Controllers
{
    [Authorize]
    public class ListsOfPatientsController : Controller
    {
        private readonly ITriageService _triageService;
        
        public ListsOfPatientsController(ITriageService triageService)
        {
            _triageService = triageService;
        }


        public async Task<IActionResult> MainList()
        {
            var patientList = await _triageService.GetAllAsync();

            return View(patientList);
        }

        public async Task<IActionResult> TodayEndList()
        {
            var patientList = await _triageService.GetAllAsync();

            return View(patientList);
        }

        public async Task<IActionResult> Statistics()
        {
            var stats = from Pacjent in await _triageService.GetAllAsync()
                        group Pacjent by Pacjent.TriageDate into dateGroup
                        select new Pacjent()
                        {
                            TriageDate = dateGroup.Key,
                            Id = dateGroup.Count()
                        };
            
            return View(stats);
        }
    }
}

