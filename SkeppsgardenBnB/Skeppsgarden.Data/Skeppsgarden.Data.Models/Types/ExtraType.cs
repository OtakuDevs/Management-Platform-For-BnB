using System.ComponentModel.DataAnnotations;
using EasyData.EntityFrameworkCore;
using Skeppsgarden.Data.Models.Enums;

namespace Skeppsgarden.Data.Models.Types;

[MetaEntity(false)]
public class ExtraType
{
    public ExtraType()
    {
        
    }
    
    public ExtraType(ExtraTypeEnums extraType) : this()
    {
        Name = extraType.ToString();
    }
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; } = null!;
    
    public ICollection<Room> Rooms { get; set; } = new HashSet<Room>();
}