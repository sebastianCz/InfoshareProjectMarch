using OstreCWEB.Data.Repository.Characters.CoreClasses;
using OstreCWEB.Data.Repository.Items;

namespace OstreCWEB.Services.Fight
{
    public interface IFightService
    {
        public Character ChooseTarget(int id);
        public CharacterActions ChooseAction(int id);
        public void InitializeFight();
        public List<Character> InitializeActions(List<Character> characterList); 
        public Enemy GetEnemyByListPosition(int enemyPositionInList);
        public List<Item> GetItems();
        public List<Enemy> GetActiveEnemies(); 
        public void UpdateActiveAction(CharacterActions action);
        public void UpdateActiveTarget(Character character);
        public PlayableCharacter GetActivePlayer();
        public List<string> ReturnHistory();
        public CharacterActions GetActiveActions();
        public Character GetActiveTarget();
        public Character ResetActiveTarget(); 
        public void CommitAction();
        public FightService GetFightState();
    }
}