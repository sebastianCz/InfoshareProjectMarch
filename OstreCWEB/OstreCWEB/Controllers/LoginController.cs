﻿
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using OstreCWEB.Data.Repository.Identity;
using OstreCWEB.Services.Identity;
using System.Net.Mail;
using System.Net;

namespace OstreCWEB.Controllers
{

    public class LoginController : Controller
    {
        private readonly IUserAuthenticationService _service;
        public LoginController(IUserAuthenticationService service)
        {
            _service = service;
        }

        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registration(Registration model)
        {
            if (!ModelState.IsValid)
                return View(model);
            model.Role = "user";
            var result = await _service.RegisterAsync(model);
            TempData["msg"] = result.Message;
            return RedirectToAction(nameof(Registration));

        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Login model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await _service.LoginAsync(model);
            if (result.StatusCode == 1)
            {
                return RedirectToAction("Index", "Profile");
            }
            else
            {
                TempData["msg"] = result.Message;
                return RedirectToAction(nameof(Login));
            }
        }
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _service.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public IActionResult ChangePassword()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePassword model)
        {
            if (!ModelState.IsValid)
            {
                //return View(model);
                var result = await _service.ChangePasswordAsync(model, User.Identity.Name);
                TempData["msg"] = result.Message;
                return RedirectToAction(nameof(ChangePassword));
            }
            return View(model);
        }
        //public bool sendEmailSMTP(int emailType, CurrentUser currentUser, out string feedback)
        //{
        //    var smtpClient = new SmtpClient("smtp.gmail.com")
        //    {
        //        Port = 587,
        //        Credentials = new NetworkCredential("ostreCGame@gmail.com", "jgkeyglxajjymsft"),
        //        EnableSsl = true,
        //    };

        //    var mailMessage = new MailMessage
        //    {
        //        From = new MailAddress("ostreCGame@gmail.com"),
        //        Subject = "",
        //        Body = "",
        //        IsBodyHtml = true,
        //    };

        //    //Forgot Password template
        //    if (emailType == 1)
        //    {
        //        mailMessage.Subject = "Ostre C Game password recovery email";
        //        mailMessage.Body = $"<h1>Hello,</h1> <br> <h2> dear {currentUser.UserName}</h2><br> You forgot your password. <br> For now the best I can do is send you your password. Here it is : <br>" +
        //            $"Your username: {currentUser.UserName} <br> Your password: {currentUser.Password} <br> Please don't forget your password going forward. <br> <b>Regards</b>,<br><b> Ostre C team</b>";

        //        mailMessage.To.Add(currentUser.Email);

        //        feedback = "Email sent on the email adress assigned to your existing account :" + currentUser.Email;
        //        smtpClient.Send(mailMessage);
        //        return true;
        //    }
        //    else
        //    {
        //        feedback = "An non existing email template was chosen";
        //        throw new Exception(feedback);
        //        return false;

        //    }

            // Admin account
            //public async Task<IActionResult> Reg()
            //{
            //    var model = new Registration
            //    {
            //        Username = "admin",
            //        Name = "admin",
            //        Email = "admin",
            //        Password = "Admin@1234"
            //    };
            //    model.Role = "admin";
            //    var result = await this._service.RegistrationAsync(model);
            //    return Ok(result);
            //}
        }
    
}
