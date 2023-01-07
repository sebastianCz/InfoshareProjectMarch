using OstreCWEB.Data.DataBase.ManyToMany;
using OstreCWEB.Data.Interfaces;

namespace OstreCWEB.Services.GameService
{
    public class GameService : IGameService
    {
        private readonly IStoryRepository _storyRepository;
        private readonly IUserParagraphRepostiory _userParagraphRepostiory;

        public GameService(IStoryRepository storyRepository, IUserParagraphRepostiory userParagraphRepostiory)
        {
            _storyRepository = storyRepository;
            _userParagraphRepostiory = userParagraphRepostiory;
        }

        public async Task CreateNewGame(int storyId, string userId)
        {
            var story = await _storyRepository.GetStoryById(storyId);

            var save = new UserParagraph();

            save.UserId = userId;
            save.ParagraphId = story.FirstParagraphId;
            save.ActiveGame = true;

            await _userParagraphRepostiory.AddSave(save);
        }
    }
}
