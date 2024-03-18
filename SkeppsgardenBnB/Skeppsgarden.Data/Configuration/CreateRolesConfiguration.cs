using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Skeppsgarden.Common.Constants.GeneralApplicationConstants;

namespace Skeppsgarden.Data.Configuration;

public class CreateRolesConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder
            .HasData(new IdentityRole {Id = AdminRoleId, Name = AdministratorRoleName, NormalizedName = AdministratorRoleName.ToUpperInvariant() });
    }
}