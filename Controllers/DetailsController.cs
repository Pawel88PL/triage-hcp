using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Office2010.Excel;
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
        private readonly ILocationService _locationService;
        private readonly ITimeService _timeService;
        private readonly ITriageService _triageService;
        private readonly ILogger<TriageService> _logger;


        public DetailsController(IDetailsService detailsService, ILogger<TriageService> logger,
            IListService listService, ITriageService triageService, ILocationService locationService,
            ITimeService timeService)
        {
            _detailsService = detailsService;
            _logger = logger;
            _listService = listService;
            _triageService = triageService;
            _locationService = locationService;
            _timeService = timeService;
        }


        private async Task SetViewBagDoctorsAndLocations()
        {
            var doctors = await _listService.GetAllDoctorsAsync();
            var doctorSelectList = doctors.Select(d => new {
                d.DoctorId,
                FullName = d.Name + " " + d.Surname
            }).ToList();

            ViewData["Doctors"] = new SelectList(doctorSelectList, "DoctorId", "FullName");
            var locations = await _listService.GetAllLocationsAsync();
            ViewBag.Locations = new SelectList(locations, "LocationId", "LocationName");
        }



        private async Task<IActionResult> HandleRequest(int id, string viewName)
        {
            var patient = await _detailsService.GetPatientAsync(id);

            if (patient == null)
            {
                return View("NotFound");
            }

            if (viewName == "WithoutDoctor")
            {
                patient.WaitingTime = _timeService.CalculatePatientWaitingTime(patient.StartTime, DateTime.Now);
            }
            await SetViewBagDoctorsAndLocations();
            return View(viewName, patient);
        }

        [HttpGet]
        public Task<IActionResult> WithoutDoctor(int id) => HandleRequest(id, "WithoutDoctor");

        [HttpGet]
        public Task<IActionResult> WithDoctor(int id) => HandleRequest(id, "WithDoctor");

        [HttpGet]
        public Task<IActionResult> Edit(int id) => HandleRequest(id, "Edit");

        [HttpGet]
        public Task<IActionResult> Done(int id) => HandleRequest(id, "Done");

        [HttpGet]
        public Task<IActionResult> Update(int id) => HandleRequest(id, "Update");


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int PatientId,
            [Bind("PatientId,Name,Surname,Pesel,Age,Gender,LocationId,Symptoms,Color," +
            "StartTime,StartDiagnosis,DoctorId,IsActive,Remarks," +
            "WhatNext,ToWhomThePatient,EndTime,WaitingTime,TotalTime," +
            "Allergies,SBP,DBP,HeartRate,Spo2,GCS,BodyTemperature")] Patient patient)
        {
            if (PatientId != patient.PatientId)
            {
                return View("NotFound");
            }

            if (!ModelState.IsValid)
            {
                await SetViewBagDoctorsAndLocations();
                return View(patient);
            }

            var patientWithCurrentLocation = await _detailsService.GetPatientAsync(PatientId);

            if (patientWithCurrentLocation == null)
            {
                return View("NotFound");
            }

            if (patientWithCurrentLocation.LocationId != patient.LocationId)
            {
                var transferResult = await _locationService.TransferPatientAsync(patient.PatientId, patientWithCurrentLocation.LocationId, patient.LocationId);

                if (!transferResult.IsSuccess)
                {
                    return HandleUpdateError(transferResult.Error, patient);
                }
            }

            var result = await _detailsService.UpdatePatientAsync(patient);

            if (result.IsSuccess)
            {
                return RedirectToAction("MainList", "ListsOfPatients");
            }

            return HandleUpdateError(result.Error, patient);
        }

        private IActionResult HandleUpdateError(Exception ex, Patient patient)
        {
            _logger.LogError(ex, "Wystąpił błąd podczas aktualizacji danych pacjenta o Id: {Id}", patient.PatientId);
            ModelState.AddModelError(string.Empty, "Wystąpił błąd podczas aktualizacji danych pacjenta. Spróbuj ponownie później.");
            return View(patient);
        }
    }
}
