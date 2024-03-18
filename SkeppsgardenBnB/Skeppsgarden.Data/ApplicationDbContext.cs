using Microsoft.AspNetCore.Identity;

using Skeppsgarden.Data.Configuration;
using Skeppsgarden.Data.Seeders;

namespace Skeppsgarden.Data;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Models;
using Models.Types;


public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<BedType> BedTypes { get; set; } = null!;
    public DbSet<ExtraType> ExtraTypes { get; set; } = null!;
    public DbSet<FacilityType> FacilityTypes { get; set; } = null!;
    public DbSet<MenuItemType> MenuItemsTypes { get; set; } = null!;
    public DbSet<RoomType> RoomTypes { get; set; } = null!;
    public DbSet<UtilityType> UtilityTypes { get; set; } = null!;
    public DbSet<ViewType> ViewTypes { get; set; } = null!;
    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Event> Events { get; set; } = null!;
    public DbSet<Hyperlink> Hyperlinks { get; set; } = null!;
    public DbSet<MenuItem> MenuItems { get; set; } = null!;
    public DbSet<RequestRoom?> Requests { get; set; } = null!;
    public DbSet<Reservation> Reservations { get; set; } = null!;
    public DbSet<HistoricalReservation> HistoricalReservations { get; set; } = null!;
    public DbSet<Restaurant> Restaurants { get; set; } = null!;
    public DbSet<Room> Rooms { get; set; } = null!;
    public DbSet<LocalPlace> LocalPlaces { get; set; } = null!;
    public DbSet<Activities> Activities { get; set; } = null!;
    public DbSet<RoomsFacilityTypes> RoomsFacilityTypes { get; set; } = null!;
    public DbSet<RoomsUtilityTypes> RoomsUtilityTypes { get; set; } = null!;
    public DbSet<BlockedDate> BlockedDates { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<RoomsFacilityTypes>(e =>
        {
            e.HasKey(k => new {k.RoomId, k.FacilityTypeId});
        });
        
        builder.Entity<RoomsUtilityTypes>(e =>
        {
            e.HasKey(k => new {k.RoomId, k.UtilityTypeId});
        });
        
        builder.Entity<Reservation>()
            .Property(r => r.CheckIn)
            .HasColumnType("timestamp without time zone");

        builder.Entity<Reservation>()
            .Property(r => r.CheckOut)
            .HasColumnType("timestamp without time zone");
        
        builder.Entity<HistoricalReservation>()
            .Property(r => r.CheckIn)
            .HasColumnType("timestamp without time zone");
        
        builder.Entity<HistoricalReservation>()
            .Property(r => r.CheckOut)
            .HasColumnType("timestamp without time zone");
        
        builder.Entity<BlockedDate>()
            .Property(r => r.StartDate)
            .HasColumnType("timestamp without time zone");
        
        builder.Entity<BlockedDate>()
            .Property(r => r.EndDate)
            .HasColumnType("timestamp without time zone");
        
        builder.Entity<MenuItem>()
            .HasOne(mi => mi.MenuItemType)
            .WithMany(mit => mit.MenuItems)
            .HasForeignKey(mi => mi.MenuItemTypeId);
        
        builder.Entity<RequestRoom>()
            .Property(r => r.CheckIn)
            .HasColumnType("timestamp without time zone");
        
        builder.Entity<RequestRoom>()
            .Property(r => r.CheckOut)
            .HasColumnType("timestamp without time zone");
        
        var enumsSeedingConfiguration = new EnumsSeedingConfiguration();
        EnumConfiguration(builder, enumsSeedingConfiguration);
        
        var seederConfiguration = new SeederConfiguration();
        builder.ApplyConfiguration<LocalPlace>(seederConfiguration);
        builder.ApplyConfiguration<Activities>(seederConfiguration);
        builder.ApplyConfiguration<Event>(seederConfiguration);
        builder.ApplyConfiguration<Room>(seederConfiguration);
        builder.ApplyConfiguration<RoomsFacilityTypes>(seederConfiguration);
        builder.ApplyConfiguration<RoomsUtilityTypes>(seederConfiguration);
        builder.ApplyConfiguration<Restaurant>(seederConfiguration);
        builder.ApplyConfiguration<MenuItem>(seederConfiguration);
        
        //Configure roles
        var roleConfiguration = new CreateRolesConfiguration();
        builder.ApplyConfiguration(roleConfiguration);
        
        //Configure the users and add roles to them
        var userConfiguration = new SeedUserConfiguration();
        builder.ApplyConfiguration<IdentityUser>(userConfiguration);
        builder.ApplyConfiguration<IdentityUserRole<string>>(userConfiguration);
        
        base.OnModelCreating(builder);
    }

    private static void EnumConfiguration(ModelBuilder builder, EnumsSeedingConfiguration enumsSeedingConfiguration)
    {
        builder.ApplyConfiguration<BedType>(enumsSeedingConfiguration);
        builder.ApplyConfiguration<ExtraType>(enumsSeedingConfiguration);
        builder.ApplyConfiguration<FacilityType>(enumsSeedingConfiguration);
        builder.ApplyConfiguration<MenuItemType>(enumsSeedingConfiguration);
        builder.ApplyConfiguration<RoomType>(enumsSeedingConfiguration);
        builder.ApplyConfiguration<UtilityType>(enumsSeedingConfiguration);
        builder.ApplyConfiguration<ViewType>(enumsSeedingConfiguration);
    }
}