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
    }
}
