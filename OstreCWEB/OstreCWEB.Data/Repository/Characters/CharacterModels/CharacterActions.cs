using OstreCWEB.Data.Repository.Characters.Enums;
using OstreCWEB.Data.Repository.Characters.MetaTags;
using System.ComponentModel.DataAnnotations;

namespace OstreCWEB.Data.Repository.Characters.CharacterModels
{

    //"using" a spell , item  or weapon is an action. 
    public class CharacterAction
    {
        //EF config
        [Key] 
        public int CharacterActionId { get; set; }
        public Status? Status { get; set; }
        public int? StatusId { get; set; }

        public List<ActionCharacter>? LinkedCharacter {get;set;} 
        public List<Item>? LinkedItems { get; set; }
        //

        public string ActionName { get; set; }
        public string ActionDescription { get; set; }
        public CharacterActionType ActionType { get; set; }
        public bool SavingThrowPossible { get; set; }
        public int Max_Dmg { get; set; }
        public int Flat_Dmg { get; set; }
        public int Hit_Dice_Nr { get; set; }
        public string PossibleTargets { get; set; }
        public bool InflictsStatus { get; set; }
        public Statistics StatForTest { get; set; }
        //Defined for actions reseting with rest.
        public int UsesMaxBeforeRest { get; set; }  
        //Defined for items which have max use before disapearing. 
        public bool AggressiveAction { get; set; }
    }
}
