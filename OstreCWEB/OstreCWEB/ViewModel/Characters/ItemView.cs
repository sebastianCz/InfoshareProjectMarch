
using OstreCWEB.Data.Repository.Characters.CharacterModels;
using OstreCWEB.Data.Repository.Characters.Enums;

namespace OstreCWEB.ViewModel.Characters
{
    public class ItemView
    {
        public ItemType ItemType { get; set; }
        public int ArmorClass { get; set; }
        public string ArmorType { get; set; }
        public int? Id { get; set; }
        public string? Name { get; set; }
        public  CharacterAction ActionToTrigger { get; set; }
    }
}
