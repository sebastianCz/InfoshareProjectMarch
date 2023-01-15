using OstreCWEB.Data.DataBase.ManyToMany;
using OstreCWEB.Data.Repository.Identity;
using OstreCWEB.Data.Repository.ManyToMany;
using OstreCWEB.Data.Repository.StoryModels;
using OstreCWEB.Data.Repository.StoryModels.Enums;

namespace OstreCWEB.Services.Game
{
    public class GameService : IGameService
    {
        private readonly IUserParagraphRepository _userParagraphRepository;
        private readonly IIdentityRepository _identityRepository;
        private readonly IStoryRepository _storyReposiotry;

        public GameService(IUserParagraphRepository userParagraphRepository, IIdentityRepository identityRepository, IStoryRepository storyRepository)
        {
            _userParagraphRepository = userParagraphRepository;
            _identityRepository = identityRepository;
            _storyReposiotry = storyRepository;
        }
        public async Task<UserParagraph> CreateNewGameInstance(string userId, int characterTemplateId, int storyId)
        {
            var userParagraph = await _userParagraphRepository.Create(userId, characterTemplateId, storyId);
            return userParagraph;
        }

        public async Task NextParagraph(string userId, int choiceId)
        {
            var userParagraph = await _userParagraphRepository.GetActiveByUserId(userId);
            userParagraph.Paragraph = await _storyReposiotry.GetParagraphById(userParagraph.Paragraph.Choices[choiceId].NextParagraphId);
            await _userParagraphRepository.Update(userParagraph);
        }

        public async Task DeleteGameInstance(int userParagrahId)
        {
            var userParagraph = await _userParagraphRepository.GetByUserParagraphIdAsync(userParagrahId);
            await _userParagraphRepository.Delete(userParagraph);
        }

        public async Task SetActiveGameInstance(int userParagraphId, string userId)
        {
            var user = await _identityRepository.GetUser(userId);
            user.UserParagraphs.ForEach(s =>
            {
                if (s.UserParagraphId == userParagraphId) { s.ActiveGame = true; }
                else { s.ActiveGame = false; }
            });
            _identityRepository.Update(user);
        }

        public async Task HealCharacter(string userId)
        {
            var userParagraph = await _userParagraphRepository.GetActiveByUserId(userId);
            userParagraph.ActiveCharacter.CurrentHealthPoints = userParagraph.ActiveCharacter.MaxHealthPoints;
            await _userParagraphRepository.Update(userParagraph);
        }

        public async Task<int> TestThrow(string userId, int rollValue)
        {
            var userParagraph = await _userParagraphRepository.GetActiveByUserId(userId);

            int testDifficulty = GetTestDifficulty(userParagraph.Paragraph.TestProp.TestDifficulty);
            int modifire = GetModifire();
            int result = rollValue + modifire;

            return result < testDifficulty ? 0 : 1; // 0 - Failure, 1 - Success
        }

        public int ThrowDice(int maxValue)
        {
            Random rnd = new Random();
            return rnd.Next(1, maxValue+1);
        }

        //Private
        private int GetTestDifficulty(TestDifficulty testDifficulty)
        {
            switch (testDifficulty)
            {
                case TestDifficulty.VeryEasy: return 5;
                case TestDifficulty.Easy: return 10;
                case TestDifficulty.Medium: return 15;
                case TestDifficulty.Hard: return 20;
                case TestDifficulty.VeryHard: return 25;
                case TestDifficulty.NearlyImpossible: return 30;
                default: throw new ArgumentOutOfRangeException();
            }
        }

        private int GetModifire()
        {
            return 0;
        }
    }
}
