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

        private static Fight _fight = new Fight();

        

        public FightController(IFightService fightService)
        {
            _fightService = fightService;
        }
        public ActionResult FightView()
        {
            var model = new FightViewModel();
            model.PlayableCharacter = _fight.Player;
            model.ActiveEnemies = _fight.GetActiveEnemies();
            model.PlayerActionCounter = _fight.PlayerActionCounter;
            model.FightHistory = _fight.FightHistory;
            return View(model);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Action(CharacterAction action, int enemyId)
        {
            try
            {
                _fightService.Action(_fight, action, enemyId);
                return RedirectToAction(nameof(FightView));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ActionOnHero(PlayableCharacter player,CharacterAction action)
        {
            try
            {
                _fightService.ActionOnHero(_fight, action);
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
            _fight.InitializeFight();
            return RedirectToAction(nameof(FightView));
        }

    }
}
