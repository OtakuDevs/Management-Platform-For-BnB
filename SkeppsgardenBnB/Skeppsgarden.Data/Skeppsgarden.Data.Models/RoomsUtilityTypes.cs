using EasyData.EntityFrameworkCore;

namespace Skeppsgarden.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Types;

[MetaEntity(false)]
public class RoomsUtilityTypes
{
    public RoomsUtilityTypes(Guid roomId, int utilityTypeId)
    {
        RoomId = roomId;
        UtilityTypeId = utilityTypeId;
    }

    [Required]
    [ForeignKey(nameof(Room))]
    public Guid RoomId { get; set; }
    
    [Required]
    public Room Room { get; set; } = null!;
    
    
    [Required]
    [ForeignKey(nameof(UtilityType))]
    public int UtilityTypeId { get; set; }
    
    [Required]
    public UtilityType UtilityType { get; set; } = null!;
}