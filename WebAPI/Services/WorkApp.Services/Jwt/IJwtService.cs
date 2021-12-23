using System.Security.Claims;
using WorkApp.Services.Common;

namespace WorkApp.Services.Jwt
{
    public interface IJwtService
    {
        public string GenerateJwtToken(string userId, Claim userType);
    }
}