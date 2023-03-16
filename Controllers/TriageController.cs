using Microsoft.AspNetCore.Mvc;

namespace triage_hcp.Controllers
{
    public class TriageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Triage()
        {
            return View();
        }
    }
}
