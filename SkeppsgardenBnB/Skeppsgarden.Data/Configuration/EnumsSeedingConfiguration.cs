using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Skeppsgarden.Data.EnumSeeders;
using Skeppsgarden.Data.Models.Enums;
using Skeppsgarden.Data.Models.Types;

namespace Skeppsgarden.Data.Configuration;

public class EnumsSeedingConfiguration : 
    IEntityTypeConfiguration<BedType>,
    IEntityTypeConfiguration<ExtraType>,
    IEntityTypeConfiguration<FacilityType>,
    IEntityTypeConfiguration<MenuItemType>,
    IEntityTypeConfiguration<RoomType>,
    IEntityTypeConfiguration<UtilityType>,
    IEntityTypeConfiguration<ViewType>
{
    public void Configure(EntityTypeBuilder<BedType> builder)
    {
        builder.HasData(new BedTypesSeeder().BedTypes);
    }
    
    public void Configure(EntityTypeBuilder<ExtraType> builder)
    {
        builder.HasData(new ExtraTypesSeeder().ExtraTypes);
    }

    public void Configure(EntityTypeBuilder<FacilityType> builder)
    {
        builder.HasData(new FacilityTypesSeeder().FacilityTypes);
    }

    public void Configure(EntityTypeBuilder<MenuItemType> builder)
    {
        builder.HasData(new MenuItemTypesSeeder().MenuItemTypes);
    }

    public void Configure(EntityTypeBuilder<RoomType> builder)
    {
        builder.HasData(new RoomTypesSeeder().RoomTypes);
    }

    public void Configure(EntityTypeBuilder<UtilityType> builder)
    {
        builder.HasData(new UtilityTypesSeeder().UtilityTypes);
    }

    public void Configure(EntityTypeBuilder<ViewType> builder)
    {
        builder.HasData(new ViewTypesSeeder().ViewTypes);
    }
}