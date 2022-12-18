using OstreCWEB.Data.Enums;

namespace OstreCWEB.Data.Repository.Characters
{
    public class CharacterActions
    {
        

        //"using" a spell , item  or weapon is an action. 
        public int Id { get; set; }
        public string ActionName { get; set; }
        public string ActionDescription { get; set; }
        public CharacterActionType ActionType { get; set; }
        public bool HitRollRequired { get; set; }
        public int? Hit_Dmg { get; set; }
        public int? Flat_Dmg { get; set; }
        public int? Hit_Dice_Nr { get; set; }
        public string PossibleTargets { get; set; }
        public bool InflictsStatus { get; set; }
        public List<string>? StatusName { get; set; }
        public Statistics StatForTest { get; set; }
    }
}
