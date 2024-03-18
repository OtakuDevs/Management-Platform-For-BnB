using System.ComponentModel.DataAnnotations;
using EasyData.EntityFrameworkCore;
using Skeppsgarden.Data.Models.Enums;

namespace Skeppsgarden.Data.Models.Types;

[MetaEntity(false)]
public class FacilityType
{
    public FacilityType()
    {
        
    }
    
    public FacilityType(FacilityTypeEnums type) : this()
    {
        Name = type.ToString();
    }
    
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; } = null!;
    
    public ICollection<RoomsFacilityTypes> RoomsFacilityTypes { get; set; } = new HashSet<RoomsFacilityTypes>();
}