using OstreCWEB.Data.Repository.Characters.CoreClasses;
using OstreCWEB.Data.Repository.Fight;
using OstreCWEB.Data.Repository.Items;

namespace OstreCWEB.Services.Fight
{
    public interface IFightService
    {
        public Character ChooseTarget(int id);
        public CharacterActions ChooseAction(int id);
        public void InitializeFight();    
        public void UpdateActiveAction(CharacterActions action);
        public void UpdateActiveTarget(Character character); 
        public List<string> ReturnHistory();
        public CharacterActions GetActiveActions();
        public Character GetActiveTarget();
        public Character ResetActiveTarget(); 
        public void CommitAction();
        public FightInstance GetFightState(int userId);
        public FightInstance GetActiveFightInstance();
    }
}