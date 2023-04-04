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
    public class ModifyController : Controller
    {
        private readonly DbTriageContext _context;

        public ModifyController(DbTriageContext context)
        {
            _context = context;
        }

        // GET: Modify
        public async Task<IActionResult> Index()
        {
              return _context.Pacjenci != null ? 
                          View(await _context.Pacjenci.ToListAsync()) :
                          Problem("Entity set 'DbTriageContext.Pacjenci'  is null.");
        }

        // GET: Modify/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pacjenci == null)
            {
                return NotFound();
            }

            var pacjent = await _context.Pacjenci
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pacjent == null)
            {
                return NotFound();
            }

            return View(pacjent);
        }

        // GET: Modify/Edit/5
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Surname,Pesel,Age,Gender,Room,Diagnosis,Color,DateTime,Doctor,Active,Epikryza,ObserwacjeRatPiel,CoDalejZPacjentem")] Pacjent pacjent)
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

        // GET: Modify/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pacjenci == null)
            {
                return NotFound();
            }

            var pacjent = await _context.Pacjenci
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pacjent == null)
            {
                return NotFound();
            }

            return View(pacjent);
        }

        // POST: Modify/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pacjenci == null)
            {
                return Problem("Entity set 'DbTriageContext.Pacjenci'  is null.");
            }
            var pacjent = await _context.Pacjenci.FindAsync(id);
            if (pacjent != null)
            {
                _context.Pacjenci.Remove(pacjent);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PacjentExists(int id)
        {
          return (_context.Pacjenci?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
