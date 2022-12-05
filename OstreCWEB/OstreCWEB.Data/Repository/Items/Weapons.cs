using OstreCWEB.Data.Interfaces;
using OstreCWEB.Data.Enums;
using OstreCWEB.Data.Repository.Characters;

namespace OstreCWEB.Data.Repository.Items
{
    internal class Weapons :Item, IUsable,IEquipable
    {
        public CharacterActions ActionToTrigger { get; }
        public ITargetable UseItem(ITargetable itemUser, ITargetable itemTarget)
        {
            //Calculate hit% etc here , return target hp?
            return itemTarget;
        }
        public bool EquipItem(IEquipable itemToEquip, Character equippingTarget,Slot slot)
        {
            switch(slot){ 
                case Slot.SecondHand:
                    equippingTarget.EquippedSecondaryWeapon = (Item)itemToEquip;
                    return true; 
                case Slot.MainHand:
                    equippingTarget.EquippedWeapon = (Item)itemToEquip;
                    return true;
                default:
                    return false;
            }
            return false;
        }
    }
}
