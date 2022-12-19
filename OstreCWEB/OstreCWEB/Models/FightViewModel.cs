using OstreCWEB.Data.Repository.Characters;

namespace OstreCWEB.Models
{
    public class FightViewModel
    {
        public PlayableCharacter PlayableCharacter { get; set; }
        public List<Enemy> ActiveEnemies { get; set; }
        public List<string> FightHistory { get; set; }
        public int PlayerActionCounter { get; set; }   
        public CharacterActions ActiveAction { get; set; }
        public Character ActiveTarget { get; set; }
    }
}
