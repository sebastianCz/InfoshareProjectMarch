using OstreCWEB.Data.DataBase.ManyToMany;
using OstreCWEB.Data.Repository.Identity;
using System.Security.Claims;

namespace OstreCWEB.Services.Identity
{
    public interface IUserService
    {
        public string GetUserId(ClaimsPrincipal user);
        public Task<User> GetUserById(string id); 
        public Task<List<User>> GetAllUsers();
        public Task<UserParagraph> CreateNewGameInstance(string userId, int playableCharacterTemplate, int storyId);
    }
}
