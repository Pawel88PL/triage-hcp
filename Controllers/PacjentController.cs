using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using triage_hcp.Models;
using triage_hcp.Services.Interfaces;

namespace triage_hcp.Controllers
{
    public class PacjentController : Controller
    {
        private readonly ITriageService _triageService;
        
        public PacjentController(ITriageService triageService)
        {
            _triageService = triageService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Triage()
        {
            return RedirectToAction("List", "Pacjent");
        }

        public IActionResult List()
        {
            var pacjentList = _triageService.GetAll();

            return View(pacjentList);
        }
    }
}

