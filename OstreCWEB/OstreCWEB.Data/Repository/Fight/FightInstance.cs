using OstreCWEB.Data.Repository.Characters.CharacterModels;

namespace OstreCWEB.Data.Repository.Fight
{
    public class FightInstance
    {
        public  List<string> FightHistory { get; set; }
        public  List<Enemy> ActiveEnemies { get; set; } 
        public  PlayableCharacter ActivePlayer { get; set; }
        public  CharacterAction ActiveAction { get; set; }
        public  Character ActiveTarget { get; set; }
        public  int TurnNumber { get; set; }
        public  int PlayerActionCounter { get; set; }
        public  bool CombatFinished { get; set; }
        public  bool PlayerWon { get; set; }
    }
}
