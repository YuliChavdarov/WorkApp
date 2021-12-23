using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkApp.Services.Common;

namespace WorkApp.Services.Login
{
    public interface ILoginService
    {
        public Task<ServiceResultModel<string>> Login(string email, string password);
    }
}
