using Microsoft.AspNetCore.Mvc;
using OstreCWEB.Data.Repository.Characters.CharacterModels;
using OstreCWEB.Services.Characters;

namespace OstreCWEB.Controllers
{
    public class PlayableCharacterController : Controller
    {
        private readonly IPlayableCharacterService _playableCharacterService;
        public PlayableCharacterController(IPlayableCharacterService playableCharacterService)
        {
            _playableCharacterService = playableCharacterService;
        }
        public IActionResult Index()
        {
            //var model = _playableCharacterService.GetAll();
            return View();
        }
        public ActionResult Create()
        {
            Random rnd = new Random();
            ViewBag.raceId = rnd.Next(1, 6);
            ViewBag.classId = rnd.Next(1, 6);
            return View();
        }
        // POST: CharacterCreatorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PlayableCharacter model)
        {
            try
            {
                _playableCharacterService.CreateNew(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


    }
}
