using Microsoft.AspNetCore.Mvc;
using OstreCWEB.Models;
using OstreCWEB.Services;
using System.Diagnostics;
using OstreCWEB.Services.Test;

namespace OstreCWEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private TestService _testService { get; set; }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _testService = new TestService();
        }

        public ActionResult Index()
        { 
            var model = new ItemsTest();
            if (_testService.GetActiveEnemies().Any())
            {
                model.Character1 = _testService.GetEnemy(0);
                model.Character2 = _testService.GetEnemy(1);
            }  
            model.Items = _testService.GetItems();
            model.Actions = _testService.GetActions();
            model.ActiveEnemies = _testService.GetActiveEnemies();

            return View(model );
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
    }
}