using OstreCWEB.Data.Repository.Characters.Enums;

namespace OstreCWEB.ViewModel.Characters
{
    public class ItemView
    {

        public int ItemId { get; set; }
        public ItemType ItemType { get; set; }
        public int ArmorClass { get; set; }
        public string ArmorType { get; set; }
        public string? Name { get; set; }
        public  CharacterActionView ActionToTrigger { get; set; }
        public bool IsActionShowable 
        {
            get
            {
                if(this.ActionToTrigger != null)
                {
                    return true;
                }
                return false;
            }  
        }
        public bool isArmor
        {
            get
            {
                if (this.ItemType == ItemType.Armor || this.ItemType == ItemType.Shield)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
