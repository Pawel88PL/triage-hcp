using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using triage_hcp;
using triage_hcp.Models;

namespace triage_hcp.Controllers
{
    public class EditController : Controller
    {
        private readonly DbTriageContext _context;

        public EditController(DbTriageContext context)
        {
            _context = context;
        }

        // GET: Edit
        public async Task<IActionResult> Index()
        {
              return _context.Pacjenci != null ? 
                          View(await _context.Pacjenci.ToListAsync()) :
                          Problem("Entity set 'DbTriageContext.Pacjenci'  is null.");
        }

        // GET: Edit/Details/5
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

        // GET: Edit/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Edit/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Surname,Pesel,Age,Gender,Room,Diagnosis,Color,DateTime,Doctor,Active,Epikryza,ObserwacjeRatPiel,CoDalejZPacjentem")] Pacjent pacjent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pacjent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pacjent);
        }

        // GET: Edit/Edit/5
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

        // POST: Edit/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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
                return RedirectToAction("List", "Pacjent");
            }
            return View(pacjent);
        }

        // GET: Edit/Delete/5
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

        // POST: Edit/Delete/5
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
