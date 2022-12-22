using OstreCWEB.Data.Repository.Characters.CoreClasses;

namespace OstreCWEB.ViewModel.Fight
{
    public class FightViewModel
    {
        public CharacterView ActivePlayer { get; set; }
        public List<CharacterView> ActiveEnemies { get; set; }
        public List<string> FightHistory { get; set; } = new List<string>();
        public CharacterActions ActiveAction { get; set; }
        public CharacterView ActiveTarget { get; set; }
        public static int TurnNumber { get; set; }
        public static int PlayerActionCounter { get; set; }
        public static bool CombatFinished { get; set; }
        public static bool PlayerWon { get; set; }
    }
}
