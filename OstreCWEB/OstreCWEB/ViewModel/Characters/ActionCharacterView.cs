using OstreCWEB.Data.Repository.Characters.CharacterModels;

namespace OstreCWEB.ViewModel.Characters
{
    public class ActionCharacterView
    {
        public CharacterAction CharacterAction { get; set; }

        public int CharacterActionId { get; set; }

        public Character Character { get; set; }
        public int CharacterId { get; set; }
        //Amount of uses before action is not available 
        public int UsesLeftBeforeRest { get; set; }
    }
}
