using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OstreCWEB.Data.Repository.Characters;
using OstreCWEB.Services.Fight;
using OstreCWEB.ViewModel.Fight;
using OstreCWEB.ViewModel.StoryBuilder;

namespace OstreCWEB.Controllers
{
    public class FightController : Controller
    {
        private IFightService _fightService;
        private readonly IMapper _mapper;

        public FightController(IFightService fightService,IMapper mapper)
        {
            _fightService = fightService;
            _mapper = mapper;
        }
        public ActionResult FightView()
        { 
            var model = new FightViewModel();
            model.ActiveEnemies = new List<CharacterView>();
            model.ActivePlayer = _mapper.Map<CharacterView>(_fightService.GetPlayer());
            var activeEnemies = _fightService.GetActiveEnemies(); 

            foreach (var enemy in activeEnemies)  {  model.ActiveEnemies.Add(_mapper.Map<CharacterView>(enemy)); }
             
            //model.PlayerActionCounter = _fight.PlayerActionCounter; <- TODO
            model.FightHistory = _fightService.ReturnHistory();
            model.ActiveAction = _fightService.GetActiveActions();
            if (model.ActiveAction == null)
            {
                _fightService.UpdateActiveAction(_fightService.ChooseAction(1));
                model.ActiveAction = _fightService.GetActiveActions();
            }
            model.ActiveTarget = _mapper.Map<CharacterView>(_fightService.GetActiveTarget()); 
            return View(model);
        }
         

        [HttpGet]
        public ActionResult CommitPlayerAction(int targetId,int playerId,int activeActionId)
        {
            _fightService.CommitRound();
            return RedirectToAction(nameof(FightView));
        }

        [HttpGet]
        public ActionResult SetActiveAction(int id)
        {
            try
            {
                _fightService.UpdateActiveAction(_fightService.ChooseAction(id));
                //We reset active target since each action can target different types of targets.
                _fightService.ResetActiveTarget();
                return RedirectToAction(nameof(FightView));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult SetActiveTarget(int id)
        {
            try
            {
                var target = _fightService.ChooseTarget(id);
                _fightService.UpdateActiveTarget(target); 
                return RedirectToAction(nameof(FightView));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult CommitAction(int targetId,int playerId)
        {
            try
            {
                _fightService.ChooseTarget(targetId);
                return RedirectToAction(nameof(FightView));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult InitializeFight()
        {
            _fightService.InitializeFight();
            return RedirectToAction(nameof(FightView));
        }

    }
}
