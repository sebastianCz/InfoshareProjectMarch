using OstreCWEB.Data.Enums;

namespace OstreCWEB.Data.Repository.Characters
{
    internal class CharacterActions
    {
      //"using" a spell , item  or weapon is an action. 
        public int Id { get; set; }
        string ActionName { get; set; }
        string ActionDescription { get; set; }
        CharacterActionType ActionType { get; set; }
        bool HitRollRequired { get; set; }
        public int? Hit_Dmg { get; set; }
        public int? Flat_Dmg { get; set; }
        public int? Hit_Dice_Nr { get; set; }
        string PossibleTargets { get; set; }
        bool InflictsStatus { get; set; }
        List<string>? StatusName { get; set; }
        Statistics StatForTest { get; set; }
    }
}
