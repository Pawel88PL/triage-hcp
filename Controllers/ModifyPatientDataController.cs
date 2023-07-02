﻿using System;
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
    public class ModifyPatientDataController : Controller
    {
        private readonly DbTriageContext _context;

        public ModifyPatientDataController(DbTriageContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
              return _context.Pacjenci != null ? 
                          View(await _context.Pacjenci.ToListAsync()) :
                          Problem("Entity set 'DbTriageContext.Pacjenci'  is null.");
        }

        

        public async Task<IActionResult> Edit(int? id)
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
        public async Task<IActionResult> Edit(int id,
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
                return RedirectToAction(nameof(Index));
            }
            return View(pacjent);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var pacjent = await _context.Pacjenci.FindAsync(id);
            if (pacjent == null)
            {
                return NotFound();
            }

            _context.Pacjenci.Remove(pacjent);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool PacjentExists(int id)
        {
          return (_context.Pacjenci?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
