using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project2EmailNight.Context;
using Project2EmailNight.Dtos;
using Project2EmailNight.Entities;

namespace Project2EmailNight.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly EmailContext _context; 

        public ProfileController(UserManager<AppUser> userManager, EmailContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);

            ViewBag.ReceivedCount = _context.Messages.Count(x => x.ReceiverEmail == values.Email && !x.IsTrash);
            ViewBag.SentCount = _context.Messages.Count(x => x.SenderEmail == values.Email && !x.IsTrash && !x.IsDraft);
            ViewBag.DraftCount = _context.Messages.Count(x => x.SenderEmail == values.Email && x.IsDraft && !x.IsTrash);
            ViewBag.TrashCount = _context.Messages.Count(x => (x.ReceiverEmail == values.Email || x.SenderEmail == values.Email) && x.IsTrash);
            ViewBag.WorkCount = _context.Messages.Count(x => x.ReceiverEmail == values.Email && x.Category == "İş" && !x.IsTrash);
            ViewBag.FamilyCount = _context.Messages.Count(x => x.ReceiverEmail == values.Email && x.Category == "Aile" && !x.IsTrash);
            ViewBag.EducationCount = _context.Messages.Count(x => x.ReceiverEmail == values.Email && x.Category == "Eğitim" && !x.IsTrash);
            ViewBag.SocialCount = _context.Messages.Count(x => x.ReceiverEmail == values.Email && x.Category == "Sosyal" && !x.IsTrash);

            UserEditDto userEditDto = new UserEditDto();
            userEditDto.Name = values.Name;
            userEditDto.Surname = values.SurName;
            userEditDto.ImageUrl = values.ImageUrl;
            userEditDto.Email = values.Email;
            userEditDto.About = values.About; 

            ViewBag.CurrentUser = values; 

            return View(userEditDto);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserEditDto userEditDto)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            user.Name = userEditDto.Name;
            user.SurName = userEditDto.Surname;
            user.Email = userEditDto.Email;
            user.About = userEditDto.About; 

            if (!string.IsNullOrEmpty(userEditDto.Password))
            {
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, userEditDto.Password);
            }

            if (userEditDto.Image != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(userEditDto.Image.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/images/" + imageName;
                using (var stream = new FileStream(saveLocation, FileMode.Create))
                {
                    await userEditDto.Image.CopyToAsync(stream);
                }
                user.ImageUrl = imageName;
            }

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Inbox", "Message");
            }
            return View(userEditDto);
        }
    }
}