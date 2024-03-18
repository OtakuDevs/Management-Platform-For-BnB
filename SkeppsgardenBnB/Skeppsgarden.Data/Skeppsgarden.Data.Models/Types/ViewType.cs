using EasyData.EntityFrameworkCore;
using Skeppsgarden.Data.Models.Enums;

namespace Skeppsgarden.Data.Models.Types;

[MetaEntity(false)]
public class ViewType
{
    public ViewType()
    {
        
    }
    
    public ViewType(ViewTypeEnums typeEnum) : this()
    {
        Name = typeEnum.ToString();
    }
    
    public int Id { get; set; }
    
    public string Name { get; set; } = null!;
    
    public ICollection<Room> Rooms { get; set; } = new HashSet<Room>();
}