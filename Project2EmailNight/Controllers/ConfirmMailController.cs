using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project2EmailNight.Dtos;
using Project2EmailNight.Entities;

namespace Project2EmailNight.Controllers
{
    public class ConfirmMailController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ConfirmMailController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var value = TempData["Mail"];
            ViewBag.v = value;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ConfirmMailDto confirmMailDto)
        {
            var user = await _userManager.FindByEmailAsync(confirmMailDto.Mail);
            if (user == null)
            {
                ModelState.AddModelError("", "Kullanıcı bulunamadı.");
                return View(confirmMailDto);
            }

            if (user.ConfirmCode == confirmMailDto.ConfirmCode)
            {

                user.EmailConfirmed = true;
                await _userManager.UpdateAsync(user);

                return RedirectToAction("UserLogin", "Login");
            }

            ModelState.AddModelError("", "Hatalı veya eksik doğrulama kodu girdiniz.");
            return View(confirmMailDto);
        }
    }
}