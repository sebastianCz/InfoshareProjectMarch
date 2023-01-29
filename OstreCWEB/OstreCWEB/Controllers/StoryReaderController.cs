using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OstreCWEB.Data.Repository.Identity;
using OstreCWEB.Data.Repository.ManyToMany;
using OstreCWEB.Data.Repository.StoryModels.Enums;
using OstreCWEB.Services.Game;
using OstreCWEB.Services.Identity; 
using OstreCWEB.Services.StoryServices;
using OstreCWEB.ViewModel.StoryReader;

namespace OstreCWEB.Controllers
{
    [Authorize]
    public class StoryReaderController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ILogger<StoryReaderController> _logger;
        private readonly IGameService _gameService;
        private readonly IUserParagraphRepository _userParagraphRepository;
        private readonly IStoryService _storyService;
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public StoryReaderController(
            IMapper mapper, 
            ILogger<StoryReaderController> logger, 
            IGameService gameService, 
            IUserParagraphRepository userParagraphRepository, 
            IStoryService storyService,
            IUserService userService,
            IHttpContextAccessor httpContextAccessor
            )
        {
            _mapper = mapper;
            _logger = logger;
            _gameService = gameService;
            _userParagraphRepository = userParagraphRepository;
            _storyService = storyService;
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
        }


        public async Task<ActionResult> Index()
        {
            var model = new GameStageView();

            var userParagraph = await _userParagraphRepository.GetActiveByUserIdAsync(_userService.GetUserId(User));
            model.CurrentParagraph = _mapper.Map<CurrentParagraphView>(userParagraph.Paragraph);
            model.CurrentCharacter = _mapper.Map<CurrentCharacterView>(userParagraph.ActiveCharacter);

            model.Rest = userParagraph.Rest;

            if (model.CurrentParagraph.ParagraphType == ParagraphType.Test)
            {
                model.TestParagraphView = new TestParagraphView();
                model.TestParagraphView.Description = $"Roll the dice for {userParagraph.Paragraph.TestProp.AbilityScores}";
                if (_httpContextAccessor.HttpContext.Request.Cookies.Any())
                {
                    var throwCookies = _httpContextAccessor.HttpContext.Request.Cookies.Where(c => c.Key == "Throw");
                    var throwResult = Convert.ToInt32(throwCookies.ToList().FirstOrDefault().Value);
                    if (throwResult > 0)
                    {
                        model.TestParagraphView.Throw = throwResult;
                    }
                }
            }
            else
            {
                CookieOptions options = new CookieOptions();
                //This cookie will expire on session end.
                options.Expires = default(DateTime?);
                options.Path = "/";
                //Bypasses consent policy checks.
                options.IsEssential = true;
                _httpContextAccessor.HttpContext.Response.Cookies.Append("Throw", $"{0}", options);
            }
            return View(model);

            //return RedirectToAction("Index", "Home");
        }

        public async Task<ActionResult> CommitNextParagraph(int id)
        {
            await _gameService.NextParagraphAsync(_userService.GetUserId(User), id);
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> RollTheDice()
        {
            CookieOptions options = new CookieOptions();
            //This cookie will expire on session end.
            options.Expires = default(DateTime?);
            options.Path = "/";
            //Bypasses consent policy checks.
            options.IsEssential = true;
            _httpContextAccessor.HttpContext.Response.Cookies.Append("Throw", $"{_gameService.ThrowDice(20)}", options);

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> TestThrow(int id)
        {
            int resultOfThrow = await _gameService.TestThrowAsync(_userService.GetUserId(User), id);
            await _gameService.NextParagraphAsync(_userService.GetUserId(User), resultOfThrow);
            await _gameService.HealCharacterAsync(_userService.GetUserId(User));
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> HealCharacter()
        {
            await _gameService.HealCharacterAsync(_userService.GetUserId(User));
            return RedirectToAction("Index");
        }
    }
}
