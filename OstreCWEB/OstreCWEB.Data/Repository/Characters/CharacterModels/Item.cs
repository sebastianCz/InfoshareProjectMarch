using OstreCWEB.Data.Repository.Characters.Enums;
using OstreCWEB.Data.Repository.Characters.MetaTags;
using System.ComponentModel.DataAnnotations;

namespace OstreCWEB.Data.Repository.Characters.CharacterModels
{
    public class Item
    {
        //Ef Config
        [Key]
        public int ItemId { get; set; }
        public List<ItemCharacter> LinkedCharacters { get; set; }
        public CharacterAction? ActionToTrigger { get; set; }
        //
        
        public ItemType ItemType { get; set; } 

        public int? ArmorClass { get; set; }
        public ArmorType? ArmorType { get; set; }
    
        public string Name { get; set; }
        public Item() { }
        public Item(int id, string name, ItemType itemType)
        {
            ItemId = id;
            Name = name;
            ItemType = itemType;
        }

        public bool EquipItem(Item itemToEquip, Character equippingTarget, Slot slot, out string actionResult)
        {
            switch (slot)
            {
                case Slot.SecondHand:
                    equippingTarget.EquippedSecondaryWeapon = itemToEquip;
                    actionResult = $"{itemToEquip.Name}  was equipped successfully";
                    return true;
                case Slot.MainHand:
                    equippingTarget.EquippedWeapon = itemToEquip;
                    actionResult = $"{itemToEquip.Name}  was equipped successfully";
                    return true;
                default:
                    actionResult = $"{itemToEquip.Name}  cannot be quipped in this slot";
                    return false;
            }
            return false;
        }
    }
}
