using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OstreCWEB.Services.Characters;
using OstreCWEB.Services.Game;
using OstreCWEB.Services.Identity;
using OstreCWEB.Services.StoryService;
using OstreCWEB.ViewModel.Characters;
using OstreCWEB.ViewModel.Game;
using OstreCWEB.ViewModel.Identity;
using OstreCWEB.ViewModel.StoryBuilder;

namespace OstreCWEB.Controllers
{
    public class GameController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IStoryService _storyService;
        private readonly IPlayableCharacterService _playableCharacterService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IGameService _gameService;

        public GameController(IGameService gameService, IHttpContextAccessor httpContextAccessor, IUserService userService, IMapper mapper, IStoryService storyService, IPlayableCharacterService playableCharacterService)
        {
            _userService = userService;
            _mapper = mapper;
            _storyService = storyService;
            _playableCharacterService = playableCharacterService;
            _httpContextAccessor = httpContextAccessor;
            _gameService = gameService;
        }

        // GET: GameController
        [HttpGet]
        public async Task<ActionResult> StartGame()
        {
            var activeCharacterCookies = _httpContextAccessor.HttpContext.Request.Cookies.Where(c => c.Key == "ActiveCharacter");
            var activeStoryCookies = _httpContextAccessor.HttpContext.Request.Cookies.Where(c => c.Key == "ActiveStory");
            if (activeCharacterCookies != null && activeStoryCookies != null)
            {
                try
                { 
                    var gameInstance = await _gameService.CreateNewGameInstance(
                        _userService.GetUserId(User),
                        Convert.ToInt32(activeCharacterCookies.FirstOrDefault().Value),
                        Convert.ToInt32(activeStoryCookies.FirstOrDefault().Value));
                    return RedirectToAction("Index", "StoryReader"); 
                }
                catch
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {
                return RedirectToAction(nameof(Index));
            } 
        }
        public async Task<ActionResult> Index()
        { 
            var model = new StartGameView();

            if (_httpContextAccessor.HttpContext.Request.Cookies.Any())
            {
                var activeCharacterCookies = _httpContextAccessor.HttpContext.Request.Cookies.Where(c => c.Key == "ActiveCharacter");
                var activeStoryCookies = _httpContextAccessor.HttpContext.Request.Cookies.Where(c => c.Key == "ActiveStory");

                if (activeCharacterCookies.Any())
                {
                    model.ActiveCharacter = _mapper.Map<PlayableCharacterView>(await _playableCharacterService.GetById(Convert.ToInt32(activeCharacterCookies.ToList().FirstOrDefault().Value)));

                }
                if (activeStoryCookies.Any())
                {
                    model.ActiveStory = _mapper.Map<StoryView>(await _storyService.GetStoryById(Convert.ToInt32(activeStoryCookies.ToList().FirstOrDefault().Value)));
                }
            };

            model.User = _mapper.Map<UserView>(await _userService.GetUserById(_userService.GetUserId(User)));

            foreach (var story in await _storyService.GetAllStories())
            {
                var mappedStory = _mapper.Map<StoryView>(story);
                model.OtherUsersStories.Add(mappedStory);
            }

            foreach (var character in await _playableCharacterService.GetAllTemplates(_userService.GetUserId(User)))
            {
                var mappedCharacter = _mapper.Map<PlayableCharacterRow>(character);
                model.OtherUsersCharacters.Add(mappedCharacter);
            } 

            return View(model);
        }
        [HttpGet]
        public ActionResult SetActiveStory(int id)
        {
            CookieOptions options = new CookieOptions();
            //This cookie will expire on session end.
            options.Expires = default(DateTime?);
            options.Path = "/";
            //Bypasses consent policy checks.
            options.IsEssential = true;
            _httpContextAccessor.HttpContext.Response.Cookies.Append("ActiveStory", $"{id}", options);

            return RedirectToAction(nameof(Index));

        }
        [HttpGet]
        public ActionResult SetActiveCharacter(int id)
        {
            CookieOptions options = new CookieOptions();
            //This cookie will expire on session end.
            options.Expires = default(DateTime?);
            options.Path = "/";
            //Bypasses consent policy checks.
            options.IsEssential = true;
            _httpContextAccessor.HttpContext.Response.Cookies.Append("ActiveCharacter", $"{id}", options);
            return RedirectToAction(nameof(Index));
        }
        // GET: GameController/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GameController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GameController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GameController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GameController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GameController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GameController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
