using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.InkML;
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
        private readonly IListService _listService;
        private readonly ITriageService _triageService;
        private readonly ILogger<TriageService> _logger;


        public DetailsController(IDetailsService detailsService, ILogger<TriageService> logger,
            IListService listService, ITriageService triageService)
        {
            _detailsService = detailsService;
            _logger = logger;
            _listService = listService;
            _triageService = triageService;
        }

        [HttpGet]
        public async Task<IActionResult> Admin(int id)
        {
            if (_detailsService.GetPatientAsync == null)
            {
                return View("NotFound");
            }

            var patient = await _detailsService.GetPatientAsync(id);

            if (patient == null)
            {
                return View("NotFound");
            }

            var doctors = await _listService.GetAllDoctorsAsync();
            var doctorSelectList = doctors.Select(d => new {
                d.DoctorId,
                FullName = d.Name + " " + d.Surname
            }).ToList();

            ViewData["Doctors"] = new SelectList(doctorSelectList, "DoctorId", "FullName");


            return View(patient);
        }


        [HttpGet]
        public async Task<IActionResult> WithoutDoctor(int id)
        {
            if (_detailsService.GetPatientAsync == null)
            {
                return View("NotFound");
            }

            var patient = await _detailsService.GetPatientAsync(id);

            if (patient == null)
            {
                return View("NotFound");
            }

            var doctors = await _listService.GetAllDoctorsAsync();
            var doctorSelectList = doctors.Select(d => new {
                d.DoctorId,
                FullName = d.Name + " " + d.Surname
            }).ToList();

            ViewData["Doctors"] = new SelectList(doctorSelectList, "DoctorId", "FullName");

            var locations = await _triageService.GetAvailableLocationsAsync();
            ViewBag.Locations = new SelectList(locations, "LocationId", "LocationName");



            return View(patient);
        }


        [HttpGet]
        public async Task<IActionResult> WithDoctor(int id)
        {
            if (_detailsService.GetPatientAsync == null)
            {
                return View("NotFound");
            }

            var patient = await _detailsService.GetPatientAsync(id);
            
            if (patient == null)
            {
                return View("NotFound");
            }

            var doctors = await _listService.GetAllDoctorsAsync();
            var doctorSelectList = doctors.Select(d => new {
                d.DoctorId,
                FullName = d.Name + " " + d.Surname
            }).ToList();

            ViewData["Doctors"] = new SelectList(doctorSelectList, "DoctorId", "FullName");

            var locations = await _triageService.GetAvailableLocationsAsync();
            ViewBag.Locations = new SelectList(locations, "LocationId", "LocationName");


            return View(patient);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (_detailsService.GetPatientAsync == null)
            {
                return View("NotFound");
            }

            var patient = await _detailsService.GetPatientAsync(id);

            if (patient == null)
            {
                return View("NotFound");
            }


            return View(patient);
        }


        [HttpGet]
        public async Task<IActionResult> Done(int id)
        {
            if (_detailsService.GetPatientAsync == null)
            {
                return View("NotFound");
            }

            var patient = await _detailsService.GetPatientAsync(id);

            if (patient == null)
            {
                return View("NotFound");
            }


            return View(patient);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int PatientId,
            [Bind("PatientId,Name,Surname,Pesel,Age,Gender,LocationId,Symptoms,Color," +
            "StartTime,DoctorId,IsActive,Remarks," +
            "WhatNext,ToWhomThePatient,EndTime,WaitingTime,TotalTime," +
            "Allergies,SBP,DBP,HeartRate,Spo2,GCS,BodyTemperature")] Patient patient)
        {
            if (PatientId != patient.PatientId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                patient.EndTime = DateTime.Now;
                patient.TotalTime = _detailsService.CalculateTotalPatientTime(patient.StartTime, patient.EndTime);

                try
                {
                    await _detailsService.UpdatePatientAsync(patient);

                    if (!patient.IsActive)
                    {
                        var location = await _detailsService.GetLocationAsync(patient.LocationId);
                        location.IsAvailable = true;
                        await _detailsService.UpdateLocationAsync(location);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await _detailsService.GetPatientAsync(patient.PatientId) == null)
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
                    _logger.LogError(ex, "Wystąpił błąd podczas aktualizacji danych pacjenta o Id: {Id}", patient.PatientId);
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
