using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkApp.Data.Models;
using WorkApp.Data.Repositories;
using WorkApp.Services.Common;
using WorkApp.Services.Jwt;
using static WorkApp.Data.Models.Common.ModelConstants.ClaimNames;

namespace WorkApp.Services.Login
{
    public class LoginService : ILoginService
    {
        private readonly IJwtService jwtService;
        private readonly UserManager<ApplicationUser> userManager;

        public LoginService(IJwtService jwtService, UserManager<ApplicationUser> userManager)
        {
            this.jwtService = jwtService;
            this.userManager = userManager;
        }

        public async Task<ServiceResultModel<string>> Login(string email, string password)
        {
            var user = await userManager.FindByEmailAsync(email);

            if(user == null)
            {
                return new ServiceResultModel<string>
                {
                    Succeeded = false,
                    Errors = new string[] { $"User with this email was not found." }
                };
            }

            var passwordIsValid = await userManager.CheckPasswordAsync(user, password);

            if (!passwordIsValid)
            {
                return new ServiceResultModel<string>
                {
                    Succeeded = false,
                    Errors = new string[] { "Incorrect password." }
                };
            }

            var claims = await userManager.GetClaimsAsync(user);

            var userTypeClaim = claims.First(x => x.Type == UserType);

            return new ServiceResultModel<string>
            {
                Succeeded = true,
                Result = jwtService.GenerateJwtToken(user.Id, userTypeClaim)
            };
        }
    }
}
