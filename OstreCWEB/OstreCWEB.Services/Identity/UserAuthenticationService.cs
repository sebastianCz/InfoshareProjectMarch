using Microsoft.AspNetCore.Identity;
using OstreCWEB.Data.Repository.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OstreCWEB.Services.Identity
{
    
    public class UserAuthenticationService : IUserAuthenticationService
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserAuthenticationService(SignInManager<User> signInManager, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<StatusIdentity> LoginAsync(Login model)
        {
            var status = new StatusIdentity();
            var user = await userManager.FindByNameAsync(model.Username);
            if(user == null)
            {
                status.StatusCode = 0;
                status.Message = "Invalid Username";
                return status;
            }
            // matching password
            if(!await userManager.CheckPasswordAsync(user, model.Password))
            {
                status.StatusCode = 0;
                status.Message = "Invalid Password";
                return status;
            }

            var signInResult = await signInManager.PasswordSignInAsync(user, model.Password, false, true);
            if(signInResult.Succeeded)
            {
                var userRoles = await userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName)
                };
                foreach(var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role,userRole));
                }
                status.StatusCode = 1;
                status.Message = "Logged in successfully";
                return status;
            }
            else if(signInResult.IsLockedOut)
            {
                status.StatusCode = 0;
                status.Message = "User locked out";
                return status;
            }
            else
            {
                status.StatusCode = 0;
                status.Message = "Error on loggin in";
                return status;
            }
        }

        public async Task LogoutAsync()
        {   
            await signInManager.SignOutAsync();
        }

        public async Task<StatusIdentity> RegistrationAsync(Registration model)
        {
            var status = new StatusIdentity();
            var userExists = await userManager.FindByNameAsync(model.Username);
            if (userExists != null)
            {
                status.StatusCode = 0;
                status.Message = "User already exists";
                return status;
            }

            User user = new User
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                Name = model.Name,
                Email = model.Email,
                UserName = model.Username,
                EmailConfirmed = true,
            };

            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                status.StatusCode = 0;
                status.Message = "User creation failed";
                return status;
            }

            //role managment
            if (!await roleManager.RoleExistsAsync(model.Role))
                await roleManager.CreateAsync(new IdentityRole(model.Role));

            if (await roleManager.RoleExistsAsync(model.Role))
            {
                await userManager.AddToRoleAsync(user, model.Role);
            }

            status.StatusCode = 1;
            status.Message = "User has registered successfully";
            return status;

        }
    }
}
