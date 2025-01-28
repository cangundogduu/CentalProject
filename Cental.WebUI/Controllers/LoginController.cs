using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    public class LoginController(SignInManager<AppUser> _singInManager) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserLoginInfo model)
        {
            var result = await _singInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
            return View();
        } 
    }
}
