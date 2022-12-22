using OstreCWEB.Data.Enums; 
using OstreCWEB.Data.Repository.Characters;

namespace OstreCWEB.Data.Repository.Items
{
    public  class Item
    {
        public Item() { }
        public Item(int id, string name, ItemType itemType)
        {
            Id = id;
            Name = name;
            ItemType = itemType;
        }
        //TODO: Replace ItemType variable by IOC. Items will be " equipable " or not depending on type in the first itteration. 
        public ItemType ItemType { get; set; }
        public int ArmorClass { get; set; }
        public string ArmorType { get; set; }
        public int? Id { get; set; }
        public string? Name { get; set; }
        public CharacterActions ActionToTrigger { get; set; }

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
