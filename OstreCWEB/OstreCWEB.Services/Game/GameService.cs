using OstreCWEB.Data.DataBase.ManyToMany;
using OstreCWEB.Data.Repository.ManyToMany;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OstreCWEB.Data.Repository.Identity;
using OstreCWEB.Data.Repository.StoryModels;

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
            var userparagraph = await _userParagraphRepository.GetActiveByUserId(userId);
            userparagraph.Paragraph = await _storyReposiotry.GetParagraphById(userparagraph.Paragraph.Choices[choiceId].NextParagraphId);
            await _userParagraphRepository.Update(userparagraph);
        }

        public async Task DeleteGameInstance(int userParagrahId)
        {
            var userParagraph = await _userParagraphRepository.GetByUserParagraphIdAsync(userParagrahId);
            await _userParagraphRepository.Delete(userParagraph);
        }

        public async Task SetActiveGameInstance(int userParagraphId,string userId)
        { 
           var user = await _identityRepository.GetUser(userId); 
            user.UserParagraphs.ForEach(s => {  if (s.UserParagraphId == userParagraphId) { s.ActiveGame = true; }
                else { s.ActiveGame = false; }});  
            _identityRepository.Update(user);
        }
    }
}
