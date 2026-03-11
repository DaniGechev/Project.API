using Microsoft.AspNetCore.Identity;

namespace Project.API.Data;

public static class Seeder
{
    public static List<IdentityUser> SeedUsers()
    {
        var hasher = new PasswordHasher<IdentityUser>();

        var users = new List<IdentityUser>
        {
            new IdentityUser
            {
                Id = "1",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@example.com",
                NormalizedEmail = "ADMIN@EXAMPLE.COM",
                EmailConfirmed = true
            },
            new IdentityUser
            {
                Id = "2",
                UserName = "user",
                NormalizedUserName = "USER",
                Email = "user@example.com",
                NormalizedEmail = "USER@EXAMPLE.COM",
                EmailConfirmed = true
            }
        };

        users[0].PasswordHash = hasher.HashPassword(users[0], "Admin@123");
        users[1].PasswordHash = hasher.HashPassword(users[1], "User@123");

        return users;
    }
}
