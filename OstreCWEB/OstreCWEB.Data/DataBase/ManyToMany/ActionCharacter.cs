using OstreCWEB.Data.Repository.Characters.CharacterModels;
namespace OstreCWEB.Data.Repository.Characters.MetaTags
{
    public class ActionCharacter
    {
        //Ef config
       
        public CharacterAction CharacterAction { get; set; }

        public int CharacterActionId { get; set; }

        public Character Character { get; set; }
        public int CharacterId { get; set; }
    }
}
