using OstreCWEB.Data.Repository.Characters.CharacterModels;
using System.ComponentModel.DataAnnotations;

namespace OstreCWEB.Data.Repository.Characters.MetaTags
{
    public class ItemCharacter
    {
        [Key]
        public int Id { get; set; }
        public Item Item { get; set; }
        public int ItemId { get; set; } 
        public int CharacterId { get; set; }  
        public Character Character { get; set; }

        //Paremeters for items in the given relationship
        public bool IsEquipped { get; set; }
    }
}
