using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OstreCWEB.Data.Repository.ManyToMany;
using OstreCWEB.Services.Game;
using OstreCWEB.Services.Identity;
using OstreCWEB.Services.StoryService;
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

        public StoryReaderController(
            IMapper mapper, 
            ILogger<StoryReaderController> logger, 
            IGameService gameService, 
            IUserParagraphRepository userParagraphRepository, 
            IStoryService storyService,
            IUserService userService)
        {
            _mapper = mapper;
            _logger = logger;
            _gameService = gameService;
            _userParagraphRepository = userParagraphRepository;
            _storyService = storyService;
            _userService = userService;
        }


        public async Task<ActionResult> Index()
        {
            var model = new GameStageView();

            var userParagraph = await _userParagraphRepository.GetActiveByUserId(_userService.GetUserId(User));
            model.CurrentParagraph = _mapper.Map<CurrentParagraphView>(userParagraph.Paragraph);
            model.CurrentCharacter = _mapper.Map<CurrentCharacterView>(userParagraph.ActiveCharacter);
    
            return View(model);

            //return RedirectToAction("Index", "Home");
        }

        public async Task<ActionResult> CommitNextParagraph(int id)
        {
            await _gameService.NextParagraph(_userService.GetUserId(User), id);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> HealCharacter()
        {
            await _gameService.HealCharacter(_userService.GetUserId(User));
            return RedirectToAction("Index");
        }
    }
}
