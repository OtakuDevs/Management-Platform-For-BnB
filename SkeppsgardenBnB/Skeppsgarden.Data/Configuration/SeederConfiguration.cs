using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skeppsgarden.Data.Models;
using Skeppsgarden.Data.Seeders;

namespace Skeppsgarden.Data.Configuration;

public class SeederConfiguration :
    IEntityTypeConfiguration<LocalPlace>,
    IEntityTypeConfiguration<Activities>,
    IEntityTypeConfiguration<Event>,
    IEntityTypeConfiguration<Room>,
    IEntityTypeConfiguration<RoomsFacilityTypes>,
    IEntityTypeConfiguration<RoomsUtilityTypes>,
    IEntityTypeConfiguration<Restaurant>,
    IEntityTypeConfiguration<MenuItem>
{
    public void Configure(EntityTypeBuilder<LocalPlace> builder)
    {
        builder.HasData(new LocalPlacesSeeder()._LocalPlaces);
    }

    public void Configure(EntityTypeBuilder<Activities> builder)
    {
        builder.HasData(new ActivitiesSeeder()._Activities);
    }
    
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.HasData(new EventsSeeder()._Events);
    }

    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.HasData(new RoomsSeeder()._Rooms);
    }

    public void Configure(EntityTypeBuilder<RoomsFacilityTypes> builder)
    {
        builder.HasData(new RoomsSeeder()._RoomsFacilityTypes);
    }

    public void Configure(EntityTypeBuilder<RoomsUtilityTypes> builder)
    {
        builder.HasData(new RoomsSeeder()._RoomsUtilityTypes);
    }

    public void Configure(EntityTypeBuilder<Restaurant> builder)
    {
        builder.HasData(new RestaurantSeeder()._Restaurant);
    }

    public void Configure(EntityTypeBuilder<MenuItem> builder)
    {
        builder.HasData(new RestaurantSeeder()._MenuItems);
    }
}