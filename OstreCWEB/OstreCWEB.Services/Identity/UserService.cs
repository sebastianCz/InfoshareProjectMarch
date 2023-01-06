using OstreCWEB.Data.DataBase.ManyToMany;
using OstreCWEB.Data.Repository.Identity;
using System.Security.Claims;

namespace OstreCWEB.Services.Identity
{
    public class UserService : IUserService
    {
        private readonly IIdentityRepository _identityRepository;
        public UserService(IIdentityRepository identityRepository)
        {
            _identityRepository = identityRepository;
        }
    
        public async Task<List<User>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserById(string id)
        {
            return await _identityRepository.GetUser(id);
        }

        public string GetUserId(ClaimsPrincipal user)
        { 
                if (user == null) { return ""; } 

                var userId = user.FindFirst(ClaimTypes.NameIdentifier);

                if (userId == null)  { return ""; } 

                return userId.Value; 
        }

        public async Task<UserParagraph> CreateNewGameInstance(string userId,int playableCharacterTemplate,int storyId)
        { 
            var newGameInstance = await _identityRepository.CreateGameInstance(userId, playableCharacterTemplate, storyId);
            return newGameInstance;
        }
    }
}
