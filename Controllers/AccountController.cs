using Microsoft.AspNetCore.Mvc;
using triage_hcp.Models;

namespace triage_hcp.Controllers
{
    public class AccountController : Controller
    {
        [BindProperty]
        public Credential Credential { get; set; }

        public IActionResult Login()
        {
            return View();
        }


    }
}
