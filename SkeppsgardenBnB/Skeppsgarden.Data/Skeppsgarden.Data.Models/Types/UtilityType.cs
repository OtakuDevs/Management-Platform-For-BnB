using System.ComponentModel.DataAnnotations;
using EasyData.EntityFrameworkCore;
using Skeppsgarden.Data.Models.Enums;

namespace Skeppsgarden.Data.Models.Types;

[MetaEntity(false)]
public class UtilityType
{
    public UtilityType()
    {
        
    }
    
    public UtilityType(UtilityTypeEnums type) : this()
    {
        Name = type.ToString();
    }
    
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; } = null!;
    
    public ICollection<RoomsUtilityTypes> RoomsUtilityTypes { get; set; } = new HashSet<RoomsUtilityTypes>();
}