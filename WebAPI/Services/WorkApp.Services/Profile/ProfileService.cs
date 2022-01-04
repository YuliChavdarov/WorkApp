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
using static WorkApp.Services.Common.ServiceConstants;

namespace WorkApp.Services.Profile
{
    public class ProfileService : IProfileService
    {
        private readonly UserManager<ApplicationUser> userManager;

        public ProfileService(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<ServiceResultModel> CreateWorkerProfile(string userId, WorkerProfileInputModel inputModel)
        {
            var currentUser = await userManager.FindByIdAsync(userId);

            if (currentUser == null)
            {
                return new ServiceResultModel
                {
                    Succeeded = false,
                    Errors = new List<string> { ServiceConstants.Errors.UserIdNotFound }
                };
            }

            if (currentUser.ProfileCreated)
            {
                return new ServiceResultModel
                {
                    Succeeded = false,
                    Errors = new List<string> { ServiceConstants.Errors.ProfileAlreadyCreated }
                };
            }
            
            currentUser.Address = inputModel.Address;
            currentUser.ProfileCreated = true;

            await userManager.UpdateAsync(currentUser);

            await this.userManager.SetPhoneNumberAsync(currentUser, inputModel.PhoneNumber);

            await userManager.AddClaimAsync(currentUser, new Claim(ClaimNames.Title, inputModel.Title));
            await userManager.AddClaimAsync(currentUser, new Claim(ClaimNames.Description, inputModel.Description));
            await userManager.AddClaimAsync(currentUser, new Claim(ClaimNames.HourlyRate, inputModel.HourlyRate.ToString()));
            await userManager.AddClaimAsync(currentUser, new Claim(ClaimNames.City, inputModel.City));


            return new ServiceResultModel { Succeeded = true };
        }
    }
}
