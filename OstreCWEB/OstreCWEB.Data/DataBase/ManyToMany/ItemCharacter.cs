using OstreCWEB.Data.Repository.Characters.CharacterModels; 

namespace OstreCWEB.Data.Repository.Characters.MetaTags
{
    public class ItemCharacter
    {
        public Item Item { get; set; }
        public int ItemId { get; set; } 
        public int CharacterId { get; set; }  
        public Character Character { get; set; }
    }
}
