using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OstreCWEB.Data.Repository.Fight;
using OstreCWEB.Services.Fight;
using OstreCWEB.ViewModel.Fight;
using OstreCWEB.ViewModel.Characters;

namespace OstreCWEB.Controllers
{
    public class FightController : Controller
    {
        private IFightService _fightService;

        private IFightRepository _fightRepository;
        private readonly IMapper _mapper;

        public FightController(IFightService fightService,IFightRepository fightRepository,IMapper mapper)
        {
            _fightRepository = fightRepository;
            _fightService = fightService;
            _mapper = mapper;
        }
        public ActionResult FightView()
        {
            var model = _mapper.Map<FightViewModel>(_fightService.GetActiveFightInstance());
            return View(model);
        }
        [HttpGet]
        public ActionResult InitializeFight()
        {
            _fightService.InitializeFight();
            return RedirectToAction(nameof(FightView));
        }
     
        [HttpGet]
        public ActionResult SetActiveAction(int id)
        { 
                _fightService.UpdateActiveAction(_fightService.ChooseAction(id));
                //We reset active target since each action can target different types of targets.
                _fightService.ResetActiveTarget();
                return RedirectToAction(nameof(FightView)); 
        }
        [HttpGet]
        public ActionResult SetActiveTarget(int id)
        { 
                var target = _fightService.ChooseTarget(id);
                _fightService.UpdateActiveTarget(target); 
                return RedirectToAction(nameof(FightView)); 
        }
        [HttpGet]
        public ActionResult CommitPlayerAction()
        {
            _fightService.CommitAction();
            //We provide a hardcoded user ID for now to retrieve the fight instance linked to player.
            var fightState = _fightService.GetFightState(1);
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
