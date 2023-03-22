using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using triage_hcp.Models;

namespace triage_hcp.Controllers
{
    public class AccountController : Controller
    {
        
        private readonly UserManager<UserModel> _userManager;

        public AccountController(UserManager<UserModel> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Login()
         {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Register userLoginData)
        {
            if (!ModelState.IsValid)
            {
                return View(userLoginData);
            }

            // logika która loguje

            return RedirectToAction("List", "Pacjent");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Register userRegisterData)
        {
            if (!ModelState.IsValid)
            {
                return View(userRegisterData);
            }

            // logika rejestrująca
            var newUser = new UserModel
            {
                UserName = userRegisterData.UserName
            };

            await _userManager.CreateAsync(newUser, userRegisterData.Password);

            return RedirectToAction("Login", "Account");
        }

        
        public IActionResult LogOut()
        {
            return View();
        }
    }
}
