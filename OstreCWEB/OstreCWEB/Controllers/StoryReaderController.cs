using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OstreCWEB.Data.Interfaces;
using OstreCWEB.Services.GameService;
using OstreCWEB.Services.StoryService;

namespace OstreCWEB.Controllers
{
    public class StoryReaderController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IGameService _gameService;
        private readonly IUserParagraphRepostiory _userParagraphRepostiory;
        private readonly ILogger<StoryReaderController> _logger;

        public StoryReaderController(IMapper mapper, ILogger<StoryReaderController> logger, IGameService gameService, IUserParagraphRepostiory userParagraphRepostiory)
        {
            _mapper = mapper;
            _logger = logger;
            _gameService = gameService;
            _userParagraphRepostiory = userParagraphRepostiory;
        }

        public async Task<ActionResult> Index()
        {
            if (!await _userParagraphRepostiory.HasPlayerGameOpened("1870ca4c-a9ba-4209-8cc4-43c1b83dee84"))
            {
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task<ActionResult> CreatNewGame()
        {
            if (!await _userParagraphRepostiory.HasPlayerGameOpened("1870ca4c-a9ba-4209-8cc4-43c1b83dee84"))
            {
                await _gameService.CreateNewGame(1, "1870ca4c-a9ba-4209-8cc4-43c1b83dee84");
                var save = await _userParagraphRepostiory.GetLastCreateGame("1870ca4c-a9ba-4209-8cc4-43c1b83dee84");
                _logger.LogInformation($"Admin created new game", save);
            }

            return RedirectToAction("Index");
        }
    }
}
