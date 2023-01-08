using OstreCWEB.Data.DataBase.ManyToMany;

namespace OstreCWEB.Services.Game
{
    public interface IGameService
    {
        public Task<UserParagraph> CreateNewGameInstance(string userId, int characterTemplateId, int storyId);

        public Task NextParagraph(string userId, int choiceId);
    }
}
