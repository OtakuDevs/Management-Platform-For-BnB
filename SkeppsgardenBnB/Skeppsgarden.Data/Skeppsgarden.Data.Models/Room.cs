using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using EasyData.EntityFrameworkCore;

using Skeppsgarden.Data.Models.Enums;
using Skeppsgarden.Data.Models.Types;

namespace Skeppsgarden.Data.Models;

[MetaEntity(false)]
public class Room
{
    public Room()
    {
        Id = Guid.NewGuid();
    }
    
    public Guid Id { get; set; }
    
    public int RoomNumber { get; set; }
    
    [Required]
    [ForeignKey(nameof(RoomType))]
    public int RoomTypeId { get; set; }
    
    [Required]
    public RoomType RoomType { get; set; } = null!;
    
    [Required]
    [ForeignKey(nameof(BedType))]
    public int BedTypeId { get; set; }
    
    [Required]
    public BedType BedType { get; set; } = null!;
    
    
    [ForeignKey(nameof(ExtraBed))]
    public int? ExtraBedId { get; set; }
    
    public ExtraType? ExtraBed { get; set; }
    
    public int Capacity { get; set; }
    
    public int Rate { get; set; }
    
    public bool IsAvailable { get; set; }
    
    public bool IsRequested { get; set; }
    
    public string Images { get; set; } = null!;
    
    [Required]
    [ForeignKey(nameof(ViewType))]
    public int ViewTypeId { get; set; }
    
    [Required]
    public ViewType ViewType { get; set; } = null!;
    
    public ICollection<RoomsUtilityTypes> RoomsUtilityTypes { get; set; } = new HashSet<RoomsUtilityTypes>();
    
    public ICollection<RoomsFacilityTypes> RoomsFacilityTypes { get; set; } = new HashSet<RoomsFacilityTypes>();
    
    public ICollection<Reservation> Reservations { get; set; } = new HashSet<Reservation>();
    
    public ICollection<BlockedDate> BlockedDates { get; set; } = new HashSet<BlockedDate>();
}