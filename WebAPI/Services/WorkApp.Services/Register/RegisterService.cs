using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WorkApp.Data.Models;
using WorkApp.Services.Common;
using WorkApp.Services.Jwt;
using WorkApp.Services.Register.InputModels;
using static WorkApp.Services.Common.ServiceConstants;
using static WorkApp.Services.Common.ServiceConstants.ClaimNames;
using static WorkApp.Services.Common.ServiceConstants.ClaimValues;

namespace WorkApp.Services.Register
{
    public class RegisterService : IRegisterService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IJwtService jwtService;

        public RegisterService(UserManager<ApplicationUser> userManager, IJwtService jwtService)
        {
            this.userManager = userManager;
            this.jwtService = jwtService;
        }

        public async Task<ServiceResultModel<string>> RegisterUserAsync(RegisterUserInputModel inputModel)
        {
            string inputUserType = inputModel.UserType?.ToLower();

            string userType;

            if(inputUserType == WorkerUserType.ToLower())
            {
                userType = WorkerUserType;
            }
            else if (inputUserType == ClientUserType.ToLower())
            {
                userType = ClientUserType;
            }
            else
            {
                return new ServiceResultModel<string>
                {
                    Succeeded = false,
                    Errors = new string[] { Errors.UnknownUserType }
                };
            }

            var user = new ApplicationUser()
            {
                FirstName = inputModel.FirstName,
                LastName = inputModel.LastName,
                UserName = inputModel.Email,
                Email = inputModel.Email,
            };

            var result = await userManager.CreateAsync(user, inputModel.Password);

            if (!result.Succeeded)
            {
                return new ServiceResultModel<string>
                {
                    Succeeded = false,
                    Errors = result.Errors.Select(x => x.Description)
                };
            }

            Claim userTypeClaim = new Claim(UserType, userType);

            await userManager.AddClaimAsync(user, userTypeClaim);

            return new ServiceResultModel<string>
            {
                Succeeded = true,
                Result = jwtService.GenerateJwtToken(user.Id, userTypeClaim)
            };
        }
    }
}
