using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WorkApp.Services.Register;
using WorkApp.Services.Register.InputModels;

namespace WorkApp.Web.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterService registerService;

        public RegisterController(IRegisterService registerService)
        {
            this.registerService = registerService;
        }

        [HttpPost("worker")]
        public async Task<ActionResult> RegisterWorker(RegisterWorkerInputModel workerModel)
        {
            var result = await this.registerService.RegisterWorkerAsync(workerModel);

            if (result.Succeeded)
            {
                return this.Ok();
            }

            return this.BadRequest(result.Errors);
        }

        [HttpPost("client")]
        public async Task<ActionResult> RegisterClient(RegisterClientInputModel clientModel)
        {
            var result = await this.registerService.RegisterClientAsync(clientModel);

            if(result.Succeeded)
            {
                return this.Ok();
            }

            return this.BadRequest(result.Errors);
        }
    }
}
