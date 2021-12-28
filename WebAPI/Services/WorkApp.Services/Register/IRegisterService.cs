using System.Threading.Tasks;
using WorkApp.Services.Common;
using WorkApp.Services.Register.InputModels;

namespace WorkApp.Services.Register
{
    public interface IRegisterService
    {
        public Task<ServiceResultModel<string>> RegisterUserAsync(RegisterUserInputModel inputModel);
    }
}