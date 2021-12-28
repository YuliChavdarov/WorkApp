using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WorkApp.Services.Register;
using WorkApp.Services.Register.InputModels;
using WorkApp.Web.OutputModels;

namespace WorkApp.Web.Controllers
{
    [ApiController]
    [Route(ApiRoutes.Register)]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterService registerService;

        public RegisterController(IRegisterService registerService)
        {
            this.registerService = registerService;
        }

        [HttpPost]
        public async Task<ActionResult<TokenOutputModel>> RegisterUser(RegisterUserInputModel inputModel)
        {
            var result = await this.registerService.RegisterUserAsync(inputModel);

            if (result.Succeeded)
            {
                return new TokenOutputModel { Token = result.Result };
            }

            return this.BadRequest(result.Errors);
        }
    }
}
