using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OstreCWEB.Data.Repository.Identity;

namespace OstreCWEB.Services.Identity
{
    public interface IUserAuthenticationService
    {
        Task<StatusIdentity> LoginAsync(Login model);
        Task<StatusIdentity> RegistrationAsync(Registration model);
        Task LogoutAsync();
    }
}
