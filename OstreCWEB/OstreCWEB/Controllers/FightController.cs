using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OstreCWEB.Data.Repository.Fight;
using OstreCWEB.Services.Fight;
using OstreCWEB.ViewModel.Fight;
using OstreCWEB.ViewModel.Characters;
using Microsoft.AspNetCore.Authorization;
using System.Security.Principal;
using OstreCWEB.Services.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using OstreCWEB.Services.StoryServices;
using OstreCWEB.Data.Repository.ManyToMany; 

namespace OstreCWEB.Controllers
{
    [Authorize]
    public class FightController : Controller
    {
        private IFightService _fightService; 
        private IFightRepository _fightRepository;
        private IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IUserParagraphRepository _userParagraphRepository;
        private readonly ILogger<FightController> _logger;

        public FightController(
            IUserService userService,
            IFightService fightService,
            IFightRepository fightRepository,
            IMapper mapper,
            IUserParagraphRepository userParagraphRepository,
            ILogger<FightController> logger 
            )
        { 
            _fightRepository = fightRepository;  
            _fightService = fightService; 
            _mapper = mapper;
            _userService = userService;
            _userParagraphRepository = userParagraphRepository;
            _logger = logger;
        }
        [HttpGet]
        public async Task<ActionResult> InitializeFight()
        {
            try
            {
                var gameInstance = await _userParagraphRepository.GetActiveByUserId(_userService.GetUserId(User));
                if(gameInstance != null && gameInstance.Paragraph.FightProp != null) {
                    await _fightService.InitializeFightAsync(_userService.GetUserId(User),gameInstance);
                }
                else
                {
                    return RedirectToAction("Index","Game");
                }
            }
            catch(Exception ex)
            { 
                _logger.LogDebug($"{ex.Message} // Initialize fight was called but a fight instance already exists for this user."); 
            }

            return RedirectToAction(nameof(FightView));

        } 
        public async Task<ActionResult> FightView()
        {
            var activeFightInstance = _fightService.GetActiveFightInstance(_userService.GetUserId(User));
            var activeGameInstance = await _userParagraphRepository.GetActiveByUserId(_userService.GetUserId(User));
            var model = new FightViewModel(); 
            //Each game instance character id is unique. We make sure each figh instance is unique too.Players can have multiple saves per story.
           if (activeFightInstance != null && activeFightInstance.ActivePlayer.CharacterId == activeGameInstance.ActiveCharacter.CharacterId)
            {
               model = _mapper.Map<FightViewModel>(activeFightInstance);
               return View(model); 
            }
            else
            {
               return RedirectToAction(nameof(InitializeFight));
            }
         
            
        }  
        [HttpGet]
        public ActionResult SetActiveAction(int id)
        {
            var activeFightInstance = _fightService.GetActiveFightInstance(_userService.GetUserId(User));
            _fightService.UpdateActiveAction(_fightService.ChooseAction(id));
                //We reset active target since each action can target different types of targets.
                _fightService.ResetActiveTarget();
                return RedirectToAction(nameof(FightView)); 
        }
        [HttpGet]
        public ActionResult SetActiveTarget(int id)
        {
            var activeFightInstance = _fightService.GetActiveFightInstance(_userService.GetUserId(User));
            var target = _fightService.ChooseTarget(id);
                _fightService.UpdateActiveTarget(target); 
                return RedirectToAction(nameof(FightView)); 
        }
        [HttpGet]
        public ActionResult CommitPlayerAction()
        {
            var activeFightInstance = _fightService.GetActiveFightInstance(_userService.GetUserId(User));
            _fightService.CommitAction();
            //We provide a hardcoded user ID for now to retrieve the fight instance linked to player.
            var fightState = _fightService.GetFightState(_userService.GetUserId(User));
            if (fightState.CombatFinished)
            {
                //redirect to story reader and provide fightState.CombatFinished && fightState.PlayerWon.
                //We redirect to home page for now 
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction(nameof(FightView));
        }

    }
}
