using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WorkApp.Services.Login;

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
    }
}
