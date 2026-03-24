using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project2EmailNight.Dtos;
using Project2EmailNight.Entities;
using MimeKit;
using MailKit.Net.Smtp;
using System;

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
            if (!userRegisterDto.AcceptTerms)
            {
                ModelState.AddModelError("AcceptTerms", "Kayıt olmak için kullanım şartlarını kabul etmelisiniz.");
                return View(userRegisterDto);
            }

            Random rnd = new Random();
            int code = rnd.Next(100000, 1000000);

            AppUser appUser = new AppUser()
            {
                Name = userRegisterDto.Name,
                SurName = userRegisterDto.SurName,
                UserName = userRegisterDto.Username,
                Email = userRegisterDto.Email,
                ConfirmCode = code
            };
            var result = await _userManage.CreateAsync(appUser, userRegisterDto.Password);
            if (result.Succeeded)
            {
                MimeMessage mimeMessage = new MimeMessage();

                MailboxAddress mailboxAddressFrom = new MailboxAddress("Email Projesi", "orcunozsen12@gmail.com");

                MailboxAddress mailboxAddressTo = new MailboxAddress("Değerli Kullanıcımız", appUser.Email);

                mimeMessage.From.Add(mailboxAddressFrom);
                mimeMessage.To.Add(mailboxAddressTo);

                var bodyBuilder = new BodyBuilder();
                bodyBuilder.TextBody = "Kayıt işleminizi tamamlamak için doğrulama kodunuz: " + code;
                mimeMessage.Body = bodyBuilder.ToMessageBody();
                mimeMessage.Subject = "Email Doğrulama Kodu";

                using (SmtpClient client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate("orcunozsen12@gmail.com", "ekfm edkf ngfm onxw");
                    client.Send(mimeMessage);
                    client.Disconnect(true);
                }

                TempData["Mail"] = appUser.Email;

                return RedirectToAction("Index", "ConfirmMail");
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