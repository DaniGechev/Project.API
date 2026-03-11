using Microsoft.AspNetCore.Identity;

namespace Project.API.Contracts;

public interface IJwtService
{
    string GenerateToken(IdentityUser user);
}
