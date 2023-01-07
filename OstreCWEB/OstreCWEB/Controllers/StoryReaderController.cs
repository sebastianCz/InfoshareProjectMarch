using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace OstreCWEB.Controllers
{
    public class StoryReaderController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ILogger<StoryReaderController> _logger;

        public StoryReaderController(IMapper mapper, ILogger<StoryReaderController> logger)
        {
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ActionResult> Index()
        {


            return RedirectToAction("Index", "Home");
        }

        public async Task<ActionResult> CreatNewGame()
        {

            return RedirectToAction("Index");
        }
    }
}
