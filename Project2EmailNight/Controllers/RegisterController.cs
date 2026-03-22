using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project2EmailNight.Dtos;
using Project2EmailNight.Entities;

namespace Project2EmailNight.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManage;

        public RegisterController(UserManager<AppUser> userManage)
        {
            _userManage = userManage;
        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserRegisterDto userRegisterDto)
        {
            AppUser appUser = new AppUser()
            {
                Name = userRegisterDto.Name,
                SurName = userRegisterDto.SurName,
                UserName = userRegisterDto.Username,
                Email = userRegisterDto.Email,
            };
            var result = await _userManage.CreateAsync(appUser, userRegisterDto.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("UserList");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View();
        }
    }
}