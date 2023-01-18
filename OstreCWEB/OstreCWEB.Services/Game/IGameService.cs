using OstreCWEB.Data.DataBase.ManyToMany;

namespace OstreCWEB.Services.Game
{
    public interface IGameService
    {
        public Task<UserParagraph> CreateNewGameInstanceAsync(string userId, int characterTemplateId, int storyId);
        public Task DeleteGameInstanceAsync(int userParagrahId);
        public   Task SetActiveGameInstanceAsync(int userParagraphId,string userId);
        public Task NextParagraphAsync(string userId, int choiceId);
        public Task HealCharacterAsync(string userId);
    }
}
