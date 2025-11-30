using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WaggyProjectAcunmedya.Entities;
using WaggyProjectAcunmedya.Models;

namespace WaggyProjectAcunmedya.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager; 
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            // ispersistent = tarayıcı kapansa bile sistemde bile cookie kalsın mı demek istiyor.
            // lockout.. = 5 kere arka arkaya hata yaparsa işlemi kilitlemek ister misin diyoe soruyor
            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Kullanıcı adı veya şifre hatalı!");
            }


            return RedirectToAction("Index", "Category");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
    }
}
