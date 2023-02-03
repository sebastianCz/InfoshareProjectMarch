using OstreCWEB.Data.Repository.Characters.CharacterModels;
using OstreCWEB.Data.Repository.Identity;

namespace OstreCWEB.Services.Identity
{
    public interface IUserAuthenticationService
    {
        Task<StatusIdentity> LoginAsync(Login model);
        Task<StatusIdentity> RegisterAsync(Registration model);
        Task<StatusIdentity> ChangePasswordAsync(ChangePassword model, string userId);
        public bool sendEmailSMTP(int emailType, Registration registration, out string feedback);
        Task LogoutAsync();
    }
}
