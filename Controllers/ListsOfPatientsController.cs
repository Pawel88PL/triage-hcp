using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

            var doctors = await _listService.GetAllDoctorsAsync();
            var doctorSelectList = doctors.Select(d => new {
                d.DoctorId,
                FullName = d.Name + " " + d.Surname
            }).ToList();

            ViewData["Doctors"] = new SelectList(doctorSelectList, "DoctorId", "FullName");

            return View(patientList);
        }

        public async Task<IActionResult> TodayEndList()
        {
            var patientList = await _listService.GetAllAsync();

            return View(patientList);
        }

        public async Task<IActionResult> Statistics()
        {
            var stats = from Patient in await _listService.GetAllAsync()
                        group Patient by Patient.StartTime.Date into dateGroup
                        select new Patient()
                        {
                            StartTime = dateGroup.Key,
                            PatientId = dateGroup.Count()
                        };
            
            return View(stats);
        }
    }
}

