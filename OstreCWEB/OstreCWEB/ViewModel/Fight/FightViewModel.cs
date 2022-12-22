using OstreCWEB.Data.Repository.Characters;

namespace OstreCWEB.ViewModel.Fight
{
    public class FightViewModel
    {
        public CharacterView ActivePlayer { get; set; }
        public List<CharacterView> ActiveEnemies { get; set; }
        public List<string> FightHistory { get; set; } = new List<string>();
        public int PlayerActionCounter { get; set; }
        public CharacterActions ActiveAction { get; set; }
        public CharacterView ActiveTarget { get; set; }
    }
}
