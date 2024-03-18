using System.ComponentModel.DataAnnotations;
using EasyData.EntityFrameworkCore;
using Skeppsgarden.Data.Models.Enums;

namespace Skeppsgarden.Data.Models.Types;

[MetaEntity(false)]
public class BedType
{
    public BedType()
    {
        
    }
    
    public BedType(BedTypeEnums bedType) : this()
    {
        Name = bedType.ToString();
    }
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; } = null!;
    
    public ICollection<Room> Rooms { get; set; } = new HashSet<Room>();
}