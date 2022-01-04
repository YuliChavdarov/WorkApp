using System.Threading.Tasks;
using WorkApp.Services.Common;
using WorkApp.Services.Register.InputModels;

namespace WorkApp.Services.Profile
{
    public interface IProfileService
    {
        public Task<ServiceResultModel> CreateWorkerProfile(string userId, WorkerProfileInputModel inputModel);
    }
}