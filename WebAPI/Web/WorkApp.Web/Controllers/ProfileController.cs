using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WorkApp.Services.Profile;
using WorkApp.Services.Register.InputModels;
using WorkApp.Web.Extensions;
using static WorkApp.Services.Common.ServiceConstants;

namespace WorkApp.Web.Controllers
{
    [ApiController]
    [Route(ApiRoutes.Profile)]
    [Authorize]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService profileService;

        public ProfileController(IProfileService profileService)
        {
            this.profileService = profileService;
        }

        [HttpPost]
        [Authorize(Policy = PolicyNames.WorkersOnly)]
        public async Task<ActionResult> CreateWorkerProfile(WorkerProfileInputModel inputModel)
        {
            var id = this.User.GetId();
            
            var result = await this.profileService.CreateWorkerProfile(id, inputModel);

            if (result.Succeeded)
            {
                return Ok();
            }

            return this.BadRequest(result.Errors);
        }
    }
}
