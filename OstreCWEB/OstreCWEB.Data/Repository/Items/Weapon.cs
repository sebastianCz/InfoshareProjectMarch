using OstreCWEB.Data.Interfaces;
using OstreCWEB.Data.Enums;
using OstreCWEB.Data.Repository.Characters;

namespace OstreCWEB.Data.Repository.Items
{
    public class Weapon : Item, IWeapon, IEquipable
    {
        public CharacterActions? ActionToTrigger { get; set; } 
        public ITargetable UseItem(ITargetable itemUser, ITargetable itemTarget)
        {
            //Calculate hit% etc here , return target hp?
            return itemTarget;
        }
        public bool EquipItem(IEquipable itemToEquip, Character equippingTarget,Slot slot,out string actionResult)
        {
            switch(slot){ 
                case Slot.SecondHand:
                    equippingTarget.EquippedSecondaryWeapon = itemToEquip;
                    actionResult = $"{itemToEquip.Name}  was equipped successfully";
                    return true; 
                case Slot.MainHand:
                    equippingTarget.EquippedWeapon = (Weapon)itemToEquip;
                    actionResult = $"{itemToEquip.Name}  was equipped successfully";
                    return true;
                default:
                    actionResult = $"{itemToEquip.Name}  cannot be quipped in this slot";
                    return false;
            }
            return false;
        }
        public Weapon() { } 
    }
}
