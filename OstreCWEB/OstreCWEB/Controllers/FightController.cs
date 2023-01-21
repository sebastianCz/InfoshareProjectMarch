﻿using AutoMapper;
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
using OstreCWEB.Services.Game;

namespace OstreCWEB.Controllers
{
    [Authorize]
    public class FightController : Controller
    {
        private IFightService _fightService; 
        private IFightRepository _fightRepository;
        private IUserService _userService;
        private IGameService _gameService;
        private readonly IMapper _mapper;
        private readonly IUserParagraphRepository _userParagraphRepository;
        private readonly ILogger<FightController> _logger;

        public FightController(
            IUserService userService,
            IFightService fightService,
            IFightRepository fightRepository,
            IMapper mapper,
            IUserParagraphRepository userParagraphRepository,
            ILogger<FightController> logger,
            IGameService gameService
            )
        { 
            _fightRepository = fightRepository;  
            _fightService = fightService; 
            _mapper = mapper;
            _userService = userService;
            _userParagraphRepository = userParagraphRepository;
            _logger = logger;
            _gameService = gameService;
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
            var activeGameInstance = await _userParagraphRepository.GetActiveByUserId(_userService.GetUserId(User)); 
            var activeFightInstance = _fightService.GetActiveFightInstance(_userService.GetUserId(User), activeGameInstance.ActiveCharacter.CharacterId);
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
        public async Task<ActionResult> SetActiveAction(int id)
        {
            var activeGameInstance = await _userParagraphRepository.GetActiveByUserId(_userService.GetUserId(User));
            var activeFightInstance = _fightService.GetActiveFightInstance(_userService.GetUserId(User), activeGameInstance.ActiveCharacter.CharacterId);
            _fightService.UpdateActiveAction(_fightService.ChooseAction(id));
                //We reset active target since each action can target different types of targets.
                _fightService.ResetActiveTarget();
                return RedirectToAction(nameof(FightView)); 
        }
        [HttpGet]
        public async Task<ActionResult> SetActiveTarget(int id)
        {
            var activeGameInstance = await _userParagraphRepository.GetActiveByUserId(_userService.GetUserId(User));
            var activeFightInstance = _fightService.GetActiveFightInstance(_userService.GetUserId(User), activeGameInstance.ActiveCharacter.CharacterId);
            var target = _fightService.ChooseTarget(id);
                _fightService.UpdateActiveTarget(target); 
                return RedirectToAction(nameof(FightView)); 
        }
        [HttpGet]
        public async Task<ActionResult> CommitPlayerAction()
        {
            var activeGameInstance = await _userParagraphRepository.GetActiveByUserId(_userService.GetUserId(User));
            var activeFightInstance = _fightService.GetActiveFightInstance(_userService.GetUserId(User), activeGameInstance.ActiveCharacter.CharacterId);
            _fightService.CommitAction();
            var fightState = _fightService.GetFightState(_userService.GetUserId(User),activeGameInstance.ActiveCharacter.CharacterId);
            activeFightInstance.ActionGrantedByItem = false;
            _fightService.ResetActiveTarget();
            _fightService.ResetActiveAction();
            
            if (fightState.CombatFinished)
            {//TODO: Determine why user  is always loosing after having a victory
                if (fightState.PlayerWon) 
                {
                    await _gameService.NextParagraphAsync(_userService.GetUserId(User), 1);
                }
                else { await _gameService.NextParagraphAsync(_userService.GetUserId(User), 0); }  
                return RedirectToAction("Index", "StoryReader");
            }
           
            return RedirectToAction(nameof(FightView));
        } 
        public async Task<ActionResult> SetActiveActionFromItem(int id)
        {
            var activeGameInstance = await _userParagraphRepository.GetActiveByUserId(_userService.GetUserId(User));
            var activeFightInstance = _fightService.GetActiveFightInstance(_userService.GetUserId(User), activeGameInstance.ActiveCharacter.CharacterId);
            var chosenItem = activeFightInstance.ActivePlayer.LinkedItems.First(i => i.Id == id);
            activeFightInstance.IsItemToDelete = false;
            activeFightInstance.ActionGrantedByItem = true;
            if(chosenItem.Item.DeleteOnUse)
            {              
                _fightService.UpdateItemToRemove(id);
                activeFightInstance.IsItemToDelete = true; 
            } 
            _fightService.UpdateActiveAction(_fightService.ChooseAction(chosenItem.Item.ActionToTrigger.CharacterActionId));
            _fightService.ResetActiveTarget(); 
            return RedirectToAction("FightView"); 
        } 
    }
}
