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
            model.Items = _testService.GetItems();
            
            return View(model );
        }

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