using Microsoft.AspNetCore.Mvc;
using OstreCWEB.Data.Repository.Characters.CharacterModels;
using OstreCWEB.Services.Characters;
using OstreCWEB.Services.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OstreCWEB.ViewModel.Characters;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.TagHelpers;

namespace OstreCWEB.Controllers
{
    [Authorize]
    public class PlayableCharacterController : Controller
    {
        private readonly IPlayableCharacterService _playableCharacterService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public PlayableCharacterController(IPlayableCharacterService playableCharacterService, IUserService userService, IMapper mapper)
        {
            _playableCharacterService = playableCharacterService;
            _userService = userService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            //var model = _playableCharacterService.GetAll();
            return View();
        }
        public ActionResult Create()
        {
            Random rnd = new Random();

            ViewBag.classId = rnd.Next(1, 2);

            //var racesDictionary = new Dictionary<int, string>();
            //var classesDictionary = new Dictionary<int, string>();

            //var modelCharacterList = _playableCharacterService.GetAllRaces();
            //var modelCharacterList = _playableCharacterService.GetAllClasses();

            //foreach (var race in modelCharacterList)
            //{
            //    racesDictionary.Add(character.PlayableRaceId, character.RaceName);
            //}
            //foreach (var item in collection)
            //{

            //}
            //var model = new PlayableCharacterCreateView();
            //model.CharacterRaces = racesDictionary;
            //model.CharacterClasses = classesDictionary;
            //return View(model);
            return View();
        }
        // POST: CharacterCreatorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PlayableCharacterCreateView model)
        {
            try
            {

            }
            catch
            {
                return View();
            }
            
            var playableCharacter = _mapper.Map<PlayableCharacter>(model);
            playableCharacter.UserId = _userService.GetUserId(User); 
            _playableCharacterService.Create(playableCharacter);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult SetRace()
        {
            return View();
        }
        public ActionResult SetClass()
        {
            return View();
        }
        public ActionResult Summary()
        {
            return View();
        }


    }
}
