using Microsoft.AspNetCore.Mvc;
using OstreCWEB.Data.Repository.Characters.CharacterModels;
using OstreCWEB.Services.Characters;
using OstreCWEB.Services.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OstreCWEB.ViewModel.Characters;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using OstreCWEB.Data.Repository.Characters.Enums;

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

        // POST: CharacterCreatorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PlayableCharacterCreateView model)
        {
            try
            {
                var playableCharacter = _mapper.Map<PlayableCharacter>(model);
                playableCharacter.UserId = _userService.GetUserId(User);
                _playableCharacterService.Create(playableCharacter);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult SetRace()
        {
            var racesDictionary = new Dictionary<int, string>();
            var modelCharacterList = _playableCharacterService.GetAllRaces();

            foreach (var race in modelCharacterList)
            {
                racesDictionary.Add(race.PlayableRaceId, race.RaceName);
            }

            var model = new PlayableCharacterCreateView();
            model.CharacterRaces = racesDictionary;

            return View(model);
        }

        public ActionResult SetClass(PlayableCharacterCreateView model)
        {
            var classesDictionary = new Dictionary<int, string>();
            var modelCharacterList = _playableCharacterService.GetAllClasses();

            foreach (var charClass in modelCharacterList)
            {
                classesDictionary.Add(charClass.PlayableClassId, charClass.ClassName);
            }

            model.CharacterClasses = classesDictionary;
            return View(model);
        }

        public ActionResult SetAttributes(PlayableCharacterCreateView model)
        {
            ViewBag.Str = _playableCharacterService.RollDice();
            ViewBag.Dex = _playableCharacterService.RollDice();
            ViewBag.Con = _playableCharacterService.RollDice();
            ViewBag.Int = _playableCharacterService.RollDice();
            ViewBag.Wis = _playableCharacterService.RollDice();
            ViewBag.Cha = _playableCharacterService.RollDice();
            ViewBag.Sum = ViewBag.Str + ViewBag.Dex + ViewBag.Con + ViewBag.Int + ViewBag.Wis + ViewBag.Cha;
            ViewBag.AvailablePoints = 0;

            ViewBag.RaceId = model.RaceId;
            ViewBag.ClassId = model.PlayableClassId;

            var character = _playableCharacterService.GetAllClasses();

            var attributesList = new List<PlayableClassView>();

            var bonusStr = character.Where(c => c.PlayableClassId == model.RaceId).Select(c => c.StrengthBonus).FirstOrDefault();
            var bonusWis = character.Where(c => c.PlayableClassId == model.RaceId).Select(c => c.WisdomBonus).FirstOrDefault();
            var bonusInt = character.Where(c => c.PlayableClassId == model.RaceId).Select(c => c.IntelligenceBonus).FirstOrDefault();
            var className = character.Where(c => c.PlayableClassId == model.RaceId).Select(c => c.ClassName).FirstOrDefault();

            ViewBag.BonusStr = bonusStr;
            ViewBag.BonusWis = bonusWis;
            ViewBag.BonusInt = bonusInt;
            ViewBag.ClassName = className;
            //
            return View(model);
        }

        public ActionResult SetName(PlayableCharacterCreateView model)
        {
            var listName = _playableCharacterService.GetAllNames();

            ViewBag.RaceId = model.RaceId;
            ViewBag.ClassId = model.PlayableClassId;
            ViewBag.Str = model.Strenght;
            ViewBag.Dex = model.Dexterity;
            ViewBag.Con = model.Constitution;
            ViewBag.Int = model.Intelligence;
            ViewBag.Wis = model.Wisdom;
            ViewBag.Cha = model.Charisma;

            ViewBag.MaleNames = listName;



            return View(model);
        }

        public ActionResult Summary(PlayableCharacterCreateView model)
        {
            var modelCharacter = _playableCharacterService.GetAll();
            ViewBag.RaceId = model.RaceId;
            //var raceName = _playableCharacterService.GetById(model.RaceId);
            //ViewBag.RaceName = raceName;
            ViewBag.ClassId = model.PlayableClassId;
            //ViewBag.ClassName = model.CharacterClass.ClassName;
            ViewBag.Str = model.Strenght;
            ViewBag.Dex = model.Dexterity;
            ViewBag.Con = model.Constitution;
            ViewBag.Int = model.Intelligence;
            ViewBag.Wis = model.Wisdom;
            ViewBag.Cha = model.Charisma;
            ViewBag.Name = model.CharacterName;
            return View(model);
        }
        public ActionResult RollAttributePoints(PlayableCharacter model)
        {
            _playableCharacterService.RollAttributes(model);
            return RedirectToAction(nameof(SetAttributes));
        }
    }
}
