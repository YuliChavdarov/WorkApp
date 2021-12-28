using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WorkApp.Services.Login;
using WorkApp.Services.Login.InputModels;
using WorkApp.Web.OutputModels;
using static WorkApp.Services.Common.ServiceConstants;

namespace WorkApp.Web.Controllers
{
    [ApiController]
    [Route(ApiRoutes.Login)]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService loginService;

        public LoginController(ILoginService loginService)
        {
            this.loginService = loginService;
        }

        [HttpPost]
        public async Task<ActionResult<TokenOutputModel>> Login(LoginInputModel inputModel)
        {
            var result = await this.loginService.Login(inputModel.Email, inputModel.Password);
            if (result.Succeeded)
            {
                return new TokenOutputModel { Token = result.Result };
            }

            return this.BadRequest(result.Errors);
        }

        [HttpGet("workers")]
        [Authorize(Policy = PolicyNames.WorkersOnly)]
        public async Task<ActionResult> SuperSecretActionForWorkersOnly()
        {
            return this.Ok("only workers should see this");
        }

        [HttpGet("clients")]
        [Authorize(Policy = PolicyNames.ClientsOnly)]
        public async Task<ActionResult> SuperSecretActionForClientsOnly()
        {
            return this.Ok("only clients should see this");
        }
    }
}
