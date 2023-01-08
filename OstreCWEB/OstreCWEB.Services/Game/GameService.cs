using OstreCWEB.Data.DataBase.ManyToMany;
using OstreCWEB.Data.Interfaces;
using OstreCWEB.Data.Repository.ManyToMany;

namespace OstreCWEB.Services.Game
{
    public class GameService : IGameService
    {
        private readonly IUserParagraphRepository _userParagraphRepository;
        private readonly IStoryRepository _storyReposiotry;

        public GameService(IUserParagraphRepository userParagraphRepository, IStoryRepository storyRepository)
        {
            _userParagraphRepository = userParagraphRepository; 
            _storyReposiotry = storyRepository;
        }
        public async Task<UserParagraph> CreateNewGameInstance(string userId, int characterTemplateId, int storyId)
        {
            var userParagraph = await _userParagraphRepository.Create(userId, characterTemplateId, storyId);
            return userParagraph;
        }

        public async Task NextParagraph(string userId, int choiceId)
        {
            var userparagraph = await _userParagraphRepository.GetActiveByUserId(userId);
            userparagraph.Paragraph = await _storyReposiotry.GetParagraphById(userparagraph.Paragraph.Choices[choiceId].NextParagraphId);
            await _userParagraphRepository.Update(userparagraph);
        }
    }
}
