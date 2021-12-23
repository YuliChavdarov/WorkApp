using System.Threading.Tasks;
using WorkApp.Services.Common;
using WorkApp.Services.Register.InputModels;

namespace WorkApp.Services.Register
{
    public interface IRegisterService
    {
        public Task<ServiceResultModel> RegisterWorkerAsync(RegisterWorkerInputModel inputModel);
        public Task<ServiceResultModel> RegisterClientAsync(RegisterClientInputModel inputModel);
    }
}