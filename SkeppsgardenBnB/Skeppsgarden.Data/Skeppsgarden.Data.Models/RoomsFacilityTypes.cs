using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EasyData.EntityFrameworkCore;
using Skeppsgarden.Data.Models.Types;

namespace Skeppsgarden.Data.Models;

[MetaEntity(false)]
public class RoomsFacilityTypes
{
    public RoomsFacilityTypes(Guid roomId, int facilityTypeId)
    {
        RoomId = roomId;
        FacilityTypeId = facilityTypeId;
    }

    [Required]
    [ForeignKey(nameof(Room))]
    public Guid RoomId { get; set; }
    
    [Required]
    public Room Room { get; set; } = null!;
    
    [Required]
    [ForeignKey(nameof(FacilityType))]
    public int FacilityTypeId { get; set; }
    
    [Required]
    public FacilityType FacilityType { get; set; } = null!;
}