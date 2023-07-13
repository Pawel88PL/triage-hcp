using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using triage_hcp;
using triage_hcp.Models;
using triage_hcp.Services;
using triage_hcp.Services.Interfaces;

namespace triage_hcp.Controllers
{
    [Authorize]
    public class DetailsController : Controller
    {
        private readonly IDetailsService _detailsService;
        private readonly ILogger<TriageService> _logger;


        public DetailsController(IDetailsService detailsService, ILogger<TriageService> logger)
        {
            _detailsService = detailsService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Admin(int id)
        {
            if (_detailsService.GetAsync == null)
            {
                return View("NotFound");
            }

            var patient = await _detailsService.GetAsync(id);

            if (patient == null)
            {
                return View("NotFound");
            }


            return View(patient);
        }


        [HttpGet]
        public async Task<IActionResult> WithoutDoctor(int id)
        {
            if (_detailsService.GetAsync == null)
            {
                return View("NotFound");
            }

            var patient = await _detailsService.GetAsync(id);

            if (patient == null)
            {
                return View("NotFound");
            }


            return View(patient);
        }


        [HttpGet]
        public async Task<IActionResult> WithDoctor(int id)
        {
            if (_detailsService.GetAsync == null)
            {
                return View("NotFound");
            }

            var patient = await _detailsService.GetAsync(id);
            
            if (patient == null)
            {
                return View("NotFound");
            }

            
            return View(patient);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (_detailsService.GetAsync == null)
            {
                return View("NotFound");
            }

            var patient = await _detailsService.GetAsync(id);

            if (patient == null)
            {
                return View("NotFound");
            }


            return View(patient);
        }


        [HttpGet]
        public async Task<IActionResult> Done(int id)
        {
            if (_detailsService.GetAsync == null)
            {
                return View("NotFound");
            }

            var patient = await _detailsService.GetAsync(id);

            if (patient == null)
            {
                return View("NotFound");
            }


            return View(patient);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id,
            [Bind("Id,Name,Surname,Pesel,Age,Gender,Room,Diagnosis,Color," +
            "DateTime,TriageDate,Doctor,Active,Epikryza,ObserwacjeRatPiel," +
            "CoDalejZPacjentem,ToWhomThePatient,EndTime,WaitingTime,TotalTime," +
            "Allergies,SBP,DBP,HeartRate,Spo2,GCS,BodyTemperature")] Pacjent patient)
        {
            if (id != patient.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                patient.EndTime = DateTime.Now;
                patient.TotalTime = _detailsService.CalculateTotalPatientTime(patient.DateTime, patient.EndTime);

                try
                {
                    await _detailsService.UpdatePacjentAsync(patient);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await _detailsService.GetAsync(patient.Id) == null)
                    {
                        return View("NotFound");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Nie można zaktualizować danych pacjenta, " +
                            "ponieważ zostały one zmienione przez innego użytkownika. Odśwież stronę i spróbuj ponownie.");
                        return View(patient);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Wystąpił błąd podczas aktualizacji danych pacjenta o Id: {Id}", patient.Id);
                    ModelState.AddModelError(string.Empty, "Wystąpił błąd podczas aktualizacji danych pacjenta." +
                        " Spróbuj ponownie później.");
                    return View(patient);
                }
                return RedirectToAction("MainList", "ListsOfPatients");
            }
            return View(patient);
        }

    }
}
