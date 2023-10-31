using BackEnd.API.Security.Domain.Models;
using BackEnd.API.Security.Domain.Services.Communication;

namespace BackEnd.API.Security.Domain.Services;

public interface IUserService
{
    Task<AuthenticateResponse> AuthenticateAsync(AuthenticateRequest model);

    Task<IEnumerable<User>> ListAsync();

    Task<User> GetByIdAsync(int id);

    Task RegisterAsync(RegisterRequest model);
}