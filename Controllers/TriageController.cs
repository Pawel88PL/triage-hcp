using Microsoft.AspNetCore.Mvc;
using triage_hcp.Models;
using triage_hcp.Services;
using triage_hcp.Services.Interfaces;

namespace triage_hcp.Controllers
{
    public class TriageController : Controller
    {
        private readonly ITriageService _triageService;
        
        public TriageController(ITriageService triageService)
        {
            _triageService = triageService;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Triage()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Triage(Pacjent body)
        {
            if (!ModelState.IsValid)
            {
                return View(body);
            }

            var id = _triageService.Save(body);

            TempData["PacjentId"] = id;

            return RedirectToAction("Triage");
        }
    }
}
