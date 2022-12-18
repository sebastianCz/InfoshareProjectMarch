using OstreCWEB.Data.Repository;
using OstreCWEB.Services.HardCoding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstreCWEB.Services.Fight
{
    public class FightService : IFightService
    {
        public void Action(Fight fight, CharacterAction action, int enemyId)
        {
            if (action == CharacterAction.ATTACK)
            {
                var enemyToAttack = fight.Enemies.First(e => e.ID == enemyId);
                var decreaseHpBy = 1;
                enemyToAttack.HealthPoints -= decreaseHpBy;
                fight.FightHistory.Add(string.Format("Enemy {0} lost {1}, actual hp {2}",
                enemyToAttack.Name, decreaseHpBy, enemyToAttack.HealthPoints));
                fight.PlayerActionCounter--;
            }
            if (fight.PlayerActionCounter <= 0)
            {
                fight.Player.HealthPoints--;
                fight.PlayerActionCounter = fight.Player.ActionCounter;
                fight.FightHistory.Add(string.Format("Player {0} lost {1}, actual hp {2}",
                    fight.Player.Name, 1, fight.Player.HealthPoints));
            }
        }
        public void ActionOnHero(Fight fight, CharacterAction action)
        {
            if (action == CharacterAction.HEAL)
            {
                fight.Player.HealthPoints++;
                fight.FightHistory.Add(string.Format("Player {0} Healed for {1}, actual hp {2}",
                fight.Player.Name, 1, fight.Player.HealthPoints));
                fight.PlayerActionCounter--;
            }
            if (fight.PlayerActionCounter <= 0)
            {
                fight.Player.HealthPoints--;
                fight.PlayerActionCounter = fight.Player.ActionCounter;
                fight.FightHistory.Add(string.Format("Player {0} lost {1}, actual hp {2}",
                fight.Player.Name, 1, fight.Player.HealthPoints));
            }
        }

        // TODO
         
        //public void EnemyAction(Fight fight, CharacterAction action, Random random)
        //{
        //    random = new Random();
        //    List<CharacterAction> characterActions = new List<CharacterAction>();
        //    characterActions.Add(CharacterAction.ATTACK);
        //    characterActions.Add(CharacterAction.HEAL);

        //    var enemyAction = random.Next(characterActions.Count());
        //    if (fight.PlayerActionCounter <= 0)
        //    {
        //        if (enemyAction == 1)
        //        {
        //            var damage = random.Next(0, 4);
        //            var hpLost = (fight.Player.HealthPoints - damage);
        //            fight.FightHistory.Add(string.Format("Player {0} lost {1}, actual hp {2}",
        //            fight.Player.Name, 1, fight.Player.HealthPoints));
        //        }
        //    }
        //    else
        //        return;
        //}

        //public void EnemyTurn(Fight fight)
        //{
        //    if (fight.Player.ActionCounter == 0)
        //    {
        //        Random random = new Random();
        //        var damage = random.Next(0, 4);
        //        var hpLost = (fight.Player.HealthPoints - damage);
        //        fight.FightHistory.Add(string.Format("Player {0} lost {1}, actual hp {2}",
        //        fight.Player.Name, hpLost, fight.Player.HealthPoints));

        //    }
        //}
    }
}
