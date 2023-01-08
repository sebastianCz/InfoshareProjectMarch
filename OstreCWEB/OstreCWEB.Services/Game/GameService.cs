using OstreCWEB.Data.DataBase.ManyToMany;
using OstreCWEB.Data.Repository.ManyToMany;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using OstreCWEB.Data.Repository.Identity;

namespace OstreCWEB.Services.Game
{
    public class GameService : IGameService
    {
        private readonly IUserParagraphRepository _userParagraphRepository;
        private readonly IIdentityRepository _identityRepository;
        public GameService(IUserParagraphRepository userParagraphRepository,IIdentityRepository identityRepository)
        {
            _userParagraphRepository = userParagraphRepository; 
            _identityRepository = identityRepository;
        }
        public async Task<UserParagraph> CreateNewGameInstance(string userId, int characterTemplateId, int storyId)
        {
            var userParagraph = await _userParagraphRepository.Create(userId, characterTemplateId, storyId);
            return userParagraph;
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
