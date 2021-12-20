using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WorkApp.Services;
using WorkApp.Services.Data;

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

        [HttpPost]
        [Route("worker")]
        public async Task<ActionResult> RegisterWorker(RegisterWorkerInputModel workerModel)
        {
            await this.registerService.RegisterWorker(workerModel);
            return this.Ok();
        }

        [HttpPost]
        [Route("client")]
        public async Task<ActionResult> RegisterClient(RegisterClientInputModel clientModel)
        {
            await this.registerService.RegisterClient(clientModel);
            return this.Ok();
        }
    }
}
