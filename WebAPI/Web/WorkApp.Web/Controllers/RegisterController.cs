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
        private readonly IWorkerService workerService;

        public RegisterController(IWorkerService workerService)
        {
            this.workerService = workerService;
        }

        [HttpPost]
        [Route("worker")]
        public async Task<ActionResult> Post(RegisterWorkerInputModel workerModel)
        {
            await this.workerService.RegisterWorker(workerModel);
            return this.Ok();
        }
    }
}
