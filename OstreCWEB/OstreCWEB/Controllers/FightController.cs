using Microsoft.AspNetCore.Mvc;
using OstreCWEB.Data.Enums;
using OstreCWEB.Data.Repository.Characters;
using OstreCWEB.Models;
using OstreCWEB.Services.Fight;
using OstreCWEB.Services.Test;

namespace OstreCWEB.Controllers
{
    public class FightController : Controller
    {
        private IFightService _fightService;

        public FightController(IFightService fightService)
        {
            _fightService = fightService;
        }
        public ActionResult FightView()
        {
            var model = new FightViewModel();
            model.ActivePlayer = _fightService.GetPlayer();
            model.ActiveEnemies = _fightService.GetActiveEnemies();
            //model.PlayerActionCounter = _fight.PlayerActionCounter; <- TODO
            model.FightHistory = _fightService.ReturnHistory();
            model.ActiveAction = _fightService.GetActiveActions();
            if (model.ActiveAction == null)
            {
                _fightService.UpdateActiveAction(_fightService.ChooseAction(1));
                model.ActiveAction = _fightService.GetActiveActions();
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult SetActiveAction(int id)
        {
            try
            {
                _fightService.UpdateActiveAction(_fightService.ChooseAction(id));
                return RedirectToAction(nameof(FightView));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult SetActiveTarget(int targetId)
        {
            try
            {
                var target = _fightService.ChooseTarget(targetId);
                _fightService.UpdateActiveTarget(target);
                return RedirectToAction(nameof(FightView));
            }
            catch
            {
                return RedirectToAction(nameof(FightView));
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
