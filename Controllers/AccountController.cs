using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using triage_hcp.Models;

namespace triage_hcp.Controllers
{
    public class AccountController : Controller
    {
        
        private readonly UserManager<UserModel> _userManager;
        private readonly SignInManager<UserModel> _signInManager;

        public AccountController(UserManager<UserModel> userManager, SignInManager<UserModel> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;

        }

        [HttpGet]
        public IActionResult Login()
         {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login userLoginData)
        {
            if (!ModelState.IsValid)
            {
                return View(userLoginData);
            }

            // logika która loguje
            await _signInManager.PasswordSignInAsync(userLoginData.UserName, userLoginData.Password, true, false);

            ViewData["UserName"] = userLoginData.UserName;

            return RedirectToAction("MainList", "ListsOfPatients");
        }


        [Authorize]
        [HttpGet]
        public IActionResult Register_Admin33()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register_Admin33(Register userRegisterData)
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

        
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
