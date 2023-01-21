using OstreCWEB.Data.Repository.Characters.CharacterModels;

namespace OstreCWEB.ViewModel.Characters
{
    public class ActionCharacterView
    {
        public CharacterActionView CharacterAction { get; set; } 
        //Amount of uses before action is not available 
        public int UsesLeftBeforeRest { get; set; }
    }
}
