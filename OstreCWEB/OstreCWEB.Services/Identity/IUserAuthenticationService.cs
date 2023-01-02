using OstreCWEB.Data.Repository.Identity;

namespace OstreCWEB.Services.Identity
{
    public interface IUserAuthenticationService
    {
        Task<StatusIdentity> LoginAsync(Login model);
        Task<StatusIdentity> RegisterAsync(Registration model);
        Task LogoutAsync();
    }
}
