using OstreCWEB.Data.Interfaces;
using OstreCWEB.Data.Repository.Characters;

namespace OstreCWEB.Data.Repository.Items
{
    internal class Consumable :Item,IUsable
    {
        public CharacterActions ActionToTrigger {get;}
        public Consumable(CharacterActions actionToTrigger)
        {
            //Action to trigger is saved here so action "data" can be retrieved in DB and applied to target easily. 
            ActionToTrigger = actionToTrigger;
        }
        public ITargetable UseItem(ITargetable itemUser, ITargetable itemTarget)
        {
            //Find action in DB, create "new " action instance based on this, apply to target, return target result. 
            var itemTargetAfterActionWasApplied = itemTarget;
            return itemTarget;
        }
    }
}
