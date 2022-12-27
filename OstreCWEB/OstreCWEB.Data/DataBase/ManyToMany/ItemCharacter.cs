using OstreCWEB.Data.Repository.Characters.CharacterModels;
using OstreCWEB.Data.Repository.Characters.CoreClasses;

namespace OstreCWEB.Data.Repository.Characters.MetaTags
{
    public class ItemCharacter
    {
        public Item Item { get; set; }
        public int ItemId { get; set; } 
        public int PlayableCharacterId { get; set; }  
        public PlayableCharacter PlayableCharacter { get; set; }
    }
}
