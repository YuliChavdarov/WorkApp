using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WorkApp.Data.Models;
using WorkApp.Services.Common;
using WorkApp.Services.Register.InputModels;
using static WorkApp.Services.Common.ServiceConstants.ClaimNames;
using static WorkApp.Services.Common.ServiceConstants.ClaimValues;

namespace WorkApp.Services.Register
{
    public class RegisterService : IRegisterService
    {
        private readonly UserManager<ApplicationUser> userManager;

        public RegisterService(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<ServiceResultModel> RegisterWorkerAsync(RegisterWorkerInputModel inputModel)
        {
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
                return new ServiceResultModel
                {
                    Succeeded = false,
                    Errors = result.Errors.Select(x => x.Description)
                };
            }

            await userManager.AddClaimAsync(user, new Claim(UserType, WorkerUserType));

            await userManager.AddClaimAsync(user, new Claim(Description, inputModel.Description));
            await userManager.AddClaimAsync(user, new Claim(Address, inputModel.Address));
            await userManager.AddClaimAsync(user, new Claim(HourlyPayment, inputModel.HourlyPayment.ToString()));


            return new ServiceResultModel
            {
                Succeeded = true
            };
        }

        public async Task<ServiceResultModel> RegisterClientAsync(RegisterClientInputModel inputModel)
        {
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
                return new ServiceResultModel
                {
                    Succeeded = false,
                    Errors = result.Errors.Select(x => x.Description)
                };
            }

            await userManager.AddClaimAsync(user, new Claim(UserType, ClientUserType));

            await userManager.AddClaimAsync(user, new Claim(CompanyName, inputModel.CompanyName));

            return new ServiceResultModel
            {
                Succeeded = true
            };
        }
    }
}
