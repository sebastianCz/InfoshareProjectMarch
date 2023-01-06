using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OstreCWEB.Data.Interfaces;
using OstreCWEB.Services.Characters;
using OstreCWEB.Services.Identity;
using OstreCWEB.Services.StoryService;
using OstreCWEB.ViewModel.Characters;
using OstreCWEB.ViewModel.Game;
using OstreCWEB.ViewModel.Identity;
using OstreCWEB.ViewModel.StoryBuilder;
using System.Net;

namespace OstreCWEB.Controllers
{
    public class GameController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IStoryService _storyService;
        private readonly IPlayableCharacterService _playableCharacterService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GameController(IHttpContextAccessor httpContextAccessor,IUserService userService, IMapper mapper, IStoryService storyService, IPlayableCharacterService playableCharacterService)
        {
            _userService = userService;
            _mapper = mapper;
            _storyService = storyService;
            _playableCharacterService = playableCharacterService;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: GameController
        [HttpPost]
        public async Task<ActionResult> StartGame(StartGameView model)
        {
            var activeCharacterCookie = Request.Cookies["ActiveCharacter"];
            var activeStoryCookie = Request.Cookies["ActiveStory"];
            if(activeCharacterCookie != null && activeStoryCookie != null)
            {
                return RedirectToAction("Index", "StoryReader");
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
            //Redirets to story reader with character + story chosen by user. 
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
           
            

            model.User =  _mapper.Map<UserView>(await _userService.GetUserById(_userService.GetUserId(User))); 
            
            foreach(var story in await _storyService.GetAllStories()) 
            {  
                var mappedStory =_mapper.Map<StoryView>(story);
                model.OtherUsersStories.Add(mappedStory);
            }

            foreach (var character in await _playableCharacterService.GetAll(_userService.GetUserId(User)))
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
            options.Expires = DateTime.Now.AddSeconds(10);
            options.Path = "/"; 
            //Bypasses consent policy checks.
            options.IsEssential=true;   
            _httpContextAccessor.HttpContext.Response.Cookies.Append("ActiveStory", $"{id}", options);

            return RedirectToAction(nameof(Index));
           
        }
        [HttpGet]
        public ActionResult SetActiveCharacter(int id)
        {
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddMinutes(10);
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
