using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WorkApp.Services.Login;
using static WorkApp.Services.Common.ServiceConstants;

namespace WorkApp.Web.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService loginService;

        public LoginController(ILoginService loginService)
        {
            this.loginService = loginService;
        }

        public class LoginInputModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginInputModel inputModel)
        {
            var result = await this.loginService.Login(inputModel.Email, inputModel.Password);
            if (result.Succeeded)
            {
                return this.Ok(result.Result);
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
