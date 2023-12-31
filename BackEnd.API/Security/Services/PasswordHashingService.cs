using BackEnd.API.Security.Domain.Services;

namespace BackEnd.API.Security.Services;

public class PasswordHashingService : IPasswordHashingService
{
    public string GetHash(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool VerifyPassword(string password, string hashedPassword)
    {
        return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
}
