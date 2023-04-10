using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using triage_hcp.Models;
using triage_hcp.Services.Interfaces;

namespace triage_hcp.Controllers
{
    [Authorize]
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
            return View();
        }

        public IActionResult List()
        {
            var pacjentList = _triageService.GetAll();

            return View(pacjentList);
        }

        public IActionResult CompletedList()
        {
            var pacjentList = _triageService.GetAll();

            return View(pacjentList);
        }

        public IActionResult ViewAllCompleted()
        {
            var pacjentList = _triageService.GetAll();
            return View(pacjentList);
        }
    }
}

