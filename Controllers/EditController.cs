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

namespace triage_hcp.Controllers
{
    [Authorize]
    public class EditController : Controller
    {
        private readonly DbTriageContext _context;
        private DateTime _currentTime;

        public EditController(DbTriageContext context)
        {
            _context = context;
            _currentTime = DateTime.Now;
        }

        
        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pacjenci == null)
            {
                return NotFound();
            }

            var pacjent = await _context.Pacjenci.FindAsync(id);
            if (pacjent == null)
            {
                return NotFound();
            }

            DateTime StartTime = pacjent.DateTime;
            pacjent.TotalTime = CalculateTotalPatientTime(StartTime, _currentTime);
            return View(pacjent);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(int id,
            [Bind("Id,Name,Surname,Pesel,Age,Gender,Room,Diagnosis,Color," +
            "DateTime,TriageDate,Doctor,Active,Epikryza,ObserwacjeRatPiel," +
            "CoDalejZPacjentem,ToWhomThePatient,EndTime,WaitingTime,TotalTime," +
            "Allergies,SBP,DBP,HeartRate,Spo2,GCS,BodyTemperature")] Pacjent pacjent)
        {
            if (id != pacjent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                pacjent.EndTime = _currentTime;
                pacjent.TotalTime = CalculateTotalPatientTime(pacjent.DateTime, pacjent.EndTime);

                try
                {
                    _context.Update(pacjent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacjentExists(pacjent.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("MainList", "ListsOfPatients");
            }
            return View(pacjent);
        }




        public async Task<IActionResult> Done(int? id)
        {
            if (id == null || _context.Pacjenci == null)
            {
                return NotFound();
            }

            var pacjent = await _context.Pacjenci.FindAsync(id);
            if (pacjent == null)
            {
                return NotFound();
            }
            return View(pacjent);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Done(int id,
            [Bind("Id,Name,Surname,Pesel,Age,Gender,Room,Diagnosis,Color," +
            "DateTime,TriageDate,Doctor,Active,Epikryza,ObserwacjeRatPiel," +
            "CoDalejZPacjentem,ToWhomThePatient,EndTime,WaitingTime,TotalTime," +
            "Allergies,SBP,DBP,HeartRate,Spo2,GCS,BodyTemperature")] Pacjent pacjent)
        {
            if (id != pacjent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pacjent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacjentExists(pacjent.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("CompletedList", "Pacjent");
            }
            return View(pacjent);
        }


        public async Task<IActionResult> EditPatientData(int? id)
        {
            if (id == null || _context.Pacjenci == null)
            {
                return NotFound();
            }

            var pacjent = await _context.Pacjenci.FindAsync(id);
            if (pacjent == null)
            {
                return NotFound();
            }
            return View(pacjent);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPatientData(int id,
            [Bind("Id,Name,Surname,Pesel,Age,Gender,Room,Diagnosis,Color,"
            + "DateTime,TriageDate,Doctor,Active,Epikryza,ObserwacjeRatPiel,"
            + "CoDalejZPacjentem,ToWhomThePatient,EndTime,WaitingTime,TotalTime," +
            "Allergies,SBP,DBP,HeartRate,Spo2,GCS,BodyTemperature")] Pacjent pacjent)
        {
            if (id != pacjent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pacjent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacjentExists(pacjent.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("MainList", "ListsOfPatients");
            }
            return View(pacjent);
        }


        public async Task<IActionResult> WithoutDoctor(int? id)
        {
            if (id == null || _context.Pacjenci == null)
            {
                return NotFound();
            }

            var pacjent = await _context.Pacjenci.FindAsync(id);
            if (pacjent == null)
            {
                return NotFound();
            }
            return View(pacjent);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> WithoutDoctor(int id,
            [Bind("Id,Name,Surname,Pesel,Age,Gender,Room,Diagnosis,Color," +
            "DateTime,TriageDate,Doctor,Active,Epikryza,ObserwacjeRatPiel," +
            "CoDalejZPacjentem,ToWhomThePatient,EndTime,WaitingTime,TotalTime," +
            "Allergies,SBP,DBP,HeartRate,Spo2,GCS,BodyTemperature")] Pacjent pacjent)
        {
            if (id != pacjent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pacjent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacjentExists(pacjent.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("MainList", "ListsOfPatients");
            }
            return View(pacjent);
        }

        private decimal CalculateTotalPatientTime(DateTime startTime, DateTime endTime)
        {
            TimeSpan totalTime = endTime - startTime;
            double totalHours = totalTime.TotalHours;
            decimal totalPatientTime = Math.Round(Convert.ToDecimal(totalHours), 2);
            return totalPatientTime;
        }



        private bool PacjentExists(int id)
        {
          return (_context.Pacjenci?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
