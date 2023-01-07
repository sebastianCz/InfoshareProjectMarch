using OstreCWEB.Data.DataBase.ManyToMany;
using OstreCWEB.Data.Repository.ManyToMany;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstreCWEB.Services.Game
{
    public class GameService : IGameService
    {
        private readonly IUserParagraphRepository _userParagraphRepository;
        public GameService(IUserParagraphRepository userParagraphRepository)
        {
            _userParagraphRepository = userParagraphRepository; 
        }
        public async Task<UserParagraph> CreateNewGameInstance(string userId, int characterTemplateId, int storyId)
        {
            var userParagraph = await _userParagraphRepository.Create(userId, characterTemplateId, storyId);
            return userParagraph;
        }
    }
}
