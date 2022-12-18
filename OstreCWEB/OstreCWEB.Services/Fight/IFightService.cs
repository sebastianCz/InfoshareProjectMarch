using OstreCWEB.Data.Repository;
using OstreCWEB.Data.Repository.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstreCWEB.Services.Fight
{
    public interface IFightService
    {
        public void Action(Fight fight, CharacterAction action, int enemyId);
        public void ActionOnHero(Fight fight, CharacterAction action);
        //public void EnemyAction(Fight fight, CharacterAction action, Random random);
        
        //public void EnemyTurn(Fight fight);   
    }
}
