using OstreCWEB.Data.Enums;
using OstreCWEB.Data.Interfaces;
using OstreCWEB.Data.Repository.Characters;

namespace OstreCWEB.Data.Repository.Items
{
    internal class Consumable :Item,IConsumable
    {
        public CharacterActions ActionToTrigger { get; set; }
 
        public ITargetable UseItem(ITargetable itemUser, ITargetable itemTarget)
        {
            //Find action in DB, create "new " action instance based on this, apply to target, return target result. 
            var itemTargetAfterActionWasApplied = itemTarget;
            return itemTarget;
        }
    }
}
