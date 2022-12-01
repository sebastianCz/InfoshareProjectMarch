using OstreCWEB.Data.Interfaces;
using OstreCWEB.Data.Enums;
namespace OstreCWEB.Data.Repository.Items
{
    internal class Armor :Item, IEquipable
    {
        public int ArmorClass { get; set; }
        public string ArmorType { get; set; }
        public bool EquipItem(IEquipable itemToEquip, Character equippingTarget,Slot slot)
        {
            switch(slot){
                case Slot.Armor:
                    equippingTarget.EquippedArmor = (Item)itemToEquip;
                    return true; 
                default:
                    return false;
            } 
        }
    }
}
