using OstreCWEB.Data.DataBase.ManyToMany;

namespace OstreCWEB.Services.Game
{
    public interface IGameService
    {
        public Task<UserParagraph> CreateNewGameInstance(string userId, int characterTemplateId, int storyId);
        public Task DeleteGameInstance(int userParagrahId);
        public   Task SetActiveGameInstance(int userParagraphId,string userId);
        public Task NextParagraph(string userId, int choiceId);
    }
}
