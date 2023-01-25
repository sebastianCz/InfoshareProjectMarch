using OstreCWEB.ViewModel.Characters;
using OstreCWEB.ViewModel.StoryReader;

namespace OstreCWEB.ViewModel.Fight
{
    public class FightViewModel
    {
        public CurrentCharacterView ActivePlayer { get; set; }
        public List<CharacterView> ActiveEnemies { get; set; }
        public List<string> FightHistory { get; set; }
        public CharacterActionView ActiveAction { get; set; }
        public CharacterView ActiveTarget { get; set; }
        public int TurnNumber { get; set; }
        public int PlayerActionCounter { get; set; }
        public bool CombatFinished { get; set; }
        public bool PlayerWon { get; set; }
    }
}
