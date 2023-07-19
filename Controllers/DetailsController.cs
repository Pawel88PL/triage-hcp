﻿using System;
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
        private readonly ITriageService _triageService;
        private readonly ILogger<TriageService> _logger;


        public DetailsController(IDetailsService detailsService, ILogger<TriageService> logger,
            IListService listService, ITriageService triageService, ILocationService locationService)
        {
            _detailsService = detailsService;
            _logger = logger;
            _listService = listService;
            _triageService = triageService;
            _locationService = locationService;
        }


        private async Task SetViewBagDoctorsAndLocations()
        {
            var doctors = await _listService.GetAllDoctorsAsync();
            var doctorSelectList = doctors.Select(d => new {
                d.DoctorId,
                FullName = d.Name + " " + d.Surname
            }).ToList();

            ViewData["Doctors"] = new SelectList(doctorSelectList, "DoctorId", "FullName");
            var locations = await _locationService.GetAllLocationsAsync();
            ViewBag.Locations = new SelectList(locations, "LocationId", "LocationName");
        }


        private async Task<IActionResult> HandleRequest(int id, string viewName)
        {
            var patient = await _detailsService.GetPatientAsync(id);

            if (patient == null)
            {
                return View("NotFound");
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
            "StartTime,DoctorId,IsActive,Remarks," +
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
