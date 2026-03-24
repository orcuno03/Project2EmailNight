using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project2EmailNight.Dtos;
using Project2EmailNight.Entities;

namespace Project2EmailNight.Controllers
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

        [HttpGet]
        public IActionResult UserLogin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UserLogin(UserLoginDto userLoginDto)
        {
            var user = await _userManager.FindByNameAsync(userLoginDto.Username);

            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, userLoginDto.Password);

                if (passwordCheck)
                {
                    if (!user.EmailConfirmed)
                    {
                        ModelState.AddModelError("", "Lütfen email adresinizi onaylayınız.");
                        return View(userLoginDto);
                    }

                    var result = await _signInManager.PasswordSignInAsync(user, userLoginDto.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Profile");
                    }
                }
            }

            ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı.");
            return View(userLoginDto);
        }
    }
}