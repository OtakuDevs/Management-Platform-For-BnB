using EasyData.EntityFrameworkCore;

using Skeppsgarden.Data.Models.Enums;

namespace Skeppsgarden.Data.Models.Types;

[MetaEntity(false)]
public class RoomType
{
    public RoomType()
    {

    }

    public RoomType(RoomTypeEnums typeEnum) : this()
    {
        Type = typeEnum.ToString();
    }

    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public ICollection<Room> Rooms { get; set; } = new HashSet<Room>();
}