using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using triage_hcp.Models;
using triage_hcp.Services;
using triage_hcp.Services.Interfaces;

namespace triage_hcp.Controllers
{
    [Authorize]
    public class ListsOfPatientsController : Controller
    {
        private readonly IListService _listService;
        private readonly ITimeService _timeService;
        
        public ListsOfPatientsController(IListService listService, ITimeService timeService)
        {
            _listService = listService;
            _timeService = timeService;
        }


        public async Task<IActionResult> AdminList()
        {
            var patientList = await _listService.GetAllPatientsAsync();

            return View(patientList);
        }


        public async Task<IActionResult> MainList()
        {
            var patientList = await _listService.GetAllPatientsAsync();

            foreach (var patient in patientList)
            {
                patient.WaitingTime = _timeService.CalculatePatientWaitingTime(patient.StartTime, DateTime.Now);
            }

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
            var patientList = await _listService.GetAllPatientsAsync();

            return View(patientList);
        }

        public async Task<IActionResult> Statistics()
        {
            var stats = from Patient in await _listService.GetAllPatientsAsync()
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

