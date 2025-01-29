using Cental.DtoLayer.UserDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    [AllowAnonymous]
    public class LoginController(SignInManager<AppUser> _singInManager) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserLoginDto model,string? returnUrl)
        {
            var result = await _singInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Kullanıcı adı veya şifre hatalı");
                return View(model);
            }
            if (returnUrl != null) 
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Index", "AdminAbout");
        }

        public async Task<IActionResult> Logout()
        {
            await _singInManager.SignOutAsync();
            return RedirectToAction("Index", "Default");
        }
    }
}
