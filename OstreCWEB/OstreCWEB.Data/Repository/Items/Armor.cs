using OstreCWEB.Data.Interfaces;
using OstreCWEB.Data.Repository.Characters;
using OstreCWEB.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace OstreCWEB.Data.Repository.Items
{
    public class Armor : Item, IEquipable
    { 
        public int ArmorClass { get; set; }
        public string ArmorType { get; set; }
        public bool EquipItem(IEquipable itemToEquip, Character equippingTarget, Slot slot,out string actionResult )
        {
            switch (slot)
            {
                case Slot.Armor:
                    equippingTarget.EquippedArmor = (Armor)itemToEquip;
                    actionResult = $"{itemToEquip.Name} was equipped sucessfully";
                    return true;
                default:
                    actionResult = $"{itemToEquip.Name} cannot be equipped in this slot";
                    return false;
            }
        }
        public Armor() { }
    }
}

