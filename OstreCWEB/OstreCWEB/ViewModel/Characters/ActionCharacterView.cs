using OstreCWEB.Data.Repository.Characters.CharacterModels;
using OstreCWEB.Data.Repository.Characters.Enums;

namespace OstreCWEB.ViewModel.Characters
{
    public class ActionCharacterView
    {
        public CharacterActionView CharacterAction { get; set; } 
        //Amount of uses before action is not available 
        public int UsesLeftBeforeRest { get; set; }
        public bool IsShowable {
            get
            {
                return UsesLeftBeforeRest > 0 || CharacterAction.ActionType == CharacterActionType.Cantrip 
                        || CharacterAction.ActionType == CharacterActionType.SpecialAction; 
            }
        } 
    }
}
