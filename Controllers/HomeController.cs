using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using triage_hcp.Models;

namespace triage_hcp.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


    }
}