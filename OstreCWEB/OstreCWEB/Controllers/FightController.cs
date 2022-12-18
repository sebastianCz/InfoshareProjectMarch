using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using OstreCWEB.Data.Repository;
using OstreCWEB.Services.Fight;
using OstreCWEB.Services.HardCoding;
using System;

namespace OstreCWEB.Controllers
{
    public class FightController : Controller
    {
        private IFightService _fightService;

        private static Fight _fight = new Fight();

        //private Random random;
        

        public FightController(IFightService fightService)
        {
            _fightService = fightService;
        }
        public ActionResult FightView()
        {
        return View(_fight);
        }

        // POST: FightController/Action
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

        public ActionResult ActionOnHero(Player player,CharacterAction action)
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


        ////Not working yet
        ///
        //public ActionResult EnemyAction(Fight fight, CharacterAction action, Random random)
        //{
        //    try
        //    {
        //        _fightService.EnemyAction(_fight, action,random);
        //        return RedirectToAction(nameof(FightView));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
