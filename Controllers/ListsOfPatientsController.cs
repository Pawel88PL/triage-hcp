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
        private readonly IListService _listService;
        
        public ListsOfPatientsController(IListService listService)
        {
            _listService = listService;
        }


        public async Task<IActionResult> AdminList()
        {
            var patientList = await _listService.GetAllAsync();

            return View(patientList);
        }


        public async Task<IActionResult> MainList()
        {
            var patientList = await _listService.GetAllAsync();

            return View(patientList);
        }

        public async Task<IActionResult> TodayEndList()
        {
            var patientList = await _listService.GetAllAsync();

            return View(patientList);
        }

        public async Task<IActionResult> Statistics()
        {
            var stats = from Pacjent in await _listService.GetAllAsync()
                        group Pacjent by Pacjent.TriageDate into dateGroup
                        select new Patient()
                        {
                            TriageDate = dateGroup.Key,
                            Id = dateGroup.Count()
                        };
            
            return View(stats);
        }
    }
}

