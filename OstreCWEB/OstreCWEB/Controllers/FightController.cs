using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using OstreCWEB.Data.Repository;
using OstreCWEB.Services.Fight;

namespace OstreCWEB.Controllers
{
    public class FightController : Controller
    {
        private FightService _fightService;
        private static Fight _fight = new Fight();

        public FightController(FightService fightService)
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
    }
}
