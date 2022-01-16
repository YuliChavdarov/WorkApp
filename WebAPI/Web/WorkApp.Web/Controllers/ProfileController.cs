using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WorkApp.Services.Profile;
using WorkApp.Services.Register.InputModels;
using WorkApp.Web.Extensions;
using WorkApp.Web.OutputModels;
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

        [HttpPost("create")]
        public async Task<ActionResult> CreateProfile(WorkerProfileInputModel inputModel)
        {
            var id = this.User.GetId();
            
            var result = await this.profileService.CreateWorkerProfile(id, inputModel);

            if (result.Succeeded)
            {
                return Ok();
            }

            return this.BadRequest(new ErrorOutputModel(result.Errors));
        }
    }
}
