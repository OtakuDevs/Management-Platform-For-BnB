using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

//TODO: Add Email normalization after adding proper email address

namespace Skeppsgarden.Data.Configuration;

public class SeedUserConfiguration : IEntityTypeConfiguration<IdentityUser>, IEntityTypeConfiguration<IdentityUserRole<string>>
{
    private readonly IPasswordHasher<IdentityUser?> _passwordHasher = new PasswordHasher<IdentityUser?>();
    
    // TODO: Provide password before deployment

    public void Configure(EntityTypeBuilder<IdentityUser> builder)
    {
        builder
            .HasData(
                new IdentityUser
                {
                    Id = "6a0d484a-08ef-467c-ab1f-b6fb11239452",
                    UserName = "skeppsgarden-test",
                    NormalizedUserName = "skeppsgarden-test".ToUpperInvariant(),
                    Email = "skeppsgarden@test.bg",
                    EmailConfirmed = false,
                    PasswordHash = _passwordHasher.HashPassword(null, "i!NndsWhBXcUZ%8LJxZa6Q"), // Replace with your own password
                    SecurityStamp = "FODyy1DST0mx6ZlCHac8wA==" // Replace with your own Security Stamp
                });
    }

    public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
    {
        builder
            .HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "03f23900-4a30-49e1-aae0-d498b0f2a6b6",
                    UserId = "6a0d484a-08ef-467c-ab1f-b6fb11239452"
                });
    }
}