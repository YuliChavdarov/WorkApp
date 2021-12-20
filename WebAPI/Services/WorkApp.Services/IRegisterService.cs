using System.Threading.Tasks;
using WorkApp.Services.Data;

namespace WorkApp.Services
{
    public interface IRegisterService
    {
        public Task RegisterWorker(RegisterWorkerInputModel inputModel);
        public Task RegisterClient(RegisterClientInputModel inputModel);
    }
}