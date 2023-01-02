using Microsoft.AspNetCore.Mvc;
using OstreCWEB.Data.DataBase;
using OstreCWEB.Models;
using System.Diagnostics;

namespace OstreCWEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISeeder _seeder;

        public HomeController(ILogger<HomeController> logger, ISeeder seeder)
        {
            _logger = logger;
            _seeder = seeder;
        }

        public ActionResult Index()
        {
            var user = User;
            var model = new ItemsTest();

            return View(model);
        }
        //public ActionResult InitializeFight()
        //{
        //    return RedirectToAction(nameof(FightView));
        //}
       
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public ActionResult Seed()
        {
            _seeder.SeedDataBase();
            return View();
        }
    }
}