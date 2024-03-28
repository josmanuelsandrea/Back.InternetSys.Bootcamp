using BackendBootcamp.Models;
using System.IdentityModel.Tokens.Jwt;

namespace BackendBootcamp.Services
{
    public interface IAuthService
    {
        Task<LoginResponse> ReturnToken(LoginRequestModel authorization);
        int ReadToken(string token);
    }
}
