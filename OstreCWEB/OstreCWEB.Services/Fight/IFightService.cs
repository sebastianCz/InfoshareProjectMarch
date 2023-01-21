
using OstreCWEB.Data.DataBase.ManyToMany;
using OstreCWEB.Data.Repository.Characters.CharacterModels;
using OstreCWEB.Data.Repository.Fight;

namespace OstreCWEB.Services.Fight
{
    public interface IFightService
    {
        public Character ChooseTarget(int id);
        public CharacterAction ChooseAction(int id);
        public Task InitializeFightAsync(string userId,UserParagraph gameInstance);  
        public void UpdateActiveAction(CharacterAction action);
        public void UpdateActiveTarget(Character character); 
        public List<string> ReturnHistory();
        public CharacterAction GetActiveActions();
        public Character GetActiveTarget();
        public Character ResetActiveTarget(); 
        public void CommitAction();
        public FightInstance GetFightState(string userId, int characterId);
        public FightInstance GetActiveFightInstance(string userId, int characterId);
        public Task UpdateItemToRemove(int id);
        public CharacterAction ResetActiveAction();
    }
}