using Cental.DtoLayer.UserDtos;
using Cental.EntityLayer.Entities;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cental.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleAssingController(UserManager<AppUser> _userManager, RoleManager<AppRole> _roleManager) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            var userDto= new List<ResultUserDto>();
            foreach (var user in users)
            {
                var dto = new ResultUserDto();

                dto.Roles= await _userManager.GetRolesAsync(user);
                dto.Id=user.Id;
                dto.FirstName=user.FirstName;
                dto.LastName=user.LastName;
                dto.UserName = user.UserName;
                dto.Email = user.Email;
                dto.LastName = user.LastName;

                userDto.Add(dto);
            }



            return View(userDto);
        }

        [HttpGet]
        public async Task<IActionResult> AssingRole(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            ViewBag.fullName=string.Join(" ",user.FirstName,user.LastName);

            var roles = await _roleManager.Roles.ToListAsync();

            var userRoles = await _userManager.GetRolesAsync(user);

            var assingRoleDtoList = new List<AssingRoleDto>();

            foreach (var role in roles)
            {
                var model = new AssingRoleDto();
                model.UserId = user.Id;
                model.RoleName = role.Name;
                model.RoleId = role.Id;
                model.RoleExist = userRoles.Contains(role.Name);
                assingRoleDtoList.Add(model);
            }

            return View(assingRoleDtoList);
        }

        [HttpPost]
        public async Task<IActionResult> AssingRole(List<AssingRoleDto> model)
        {

            var userId = model.Select(x => x.UserId).FirstOrDefault();
            var user = await _userManager.FindByIdAsync(userId.ToString());

            foreach (var item in model)
            {
                if (item.RoleExist)
                {
                    await _userManager.AddToRoleAsync(user, item.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.RoleName);
                }
            }

            return RedirectToAction("Index");
        }
    }


}
