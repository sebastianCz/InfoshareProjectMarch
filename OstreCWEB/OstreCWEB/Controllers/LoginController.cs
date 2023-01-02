
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using OstreCWEB.Data.Repository.Identity;
using OstreCWEB.Services.Identity;

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
