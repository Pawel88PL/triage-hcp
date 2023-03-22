using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using triage_hcp.Models;
using triage_hcp.Services;
using triage_hcp.Services.Interfaces;

namespace triage_hcp.Controllers
{
    [Authorize]
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

            var Id = _triageService.Save(body);

            TempData["PacjentId"] = Id;

            return RedirectToAction("List", "Pacjent");
        }


        [HttpGet]
        public IActionResult Admin()
        {
            var pacjenci = _triageService.GetAll();
            return View(pacjenci);
        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
            var pacjent = _triageService.Get(Id);
            return View(pacjent);
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            _triageService.Delete(Id);
            return RedirectToAction("List", "Pacjent");
        }


    }
}
