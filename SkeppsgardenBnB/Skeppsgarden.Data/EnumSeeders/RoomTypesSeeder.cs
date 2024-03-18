using Skeppsgarden.Data.Models.Enums;
using Skeppsgarden.Data.Models.Types;

namespace Skeppsgarden.Data.EnumSeeders;

public class RoomTypesSeeder
{
    public readonly ICollection<RoomType> RoomTypes;
    
    public RoomTypesSeeder()
    {
        RoomTypes = new List<RoomType>();
        RoomTypes = GenerateRoomTypes();
    }
    
    private ICollection<RoomType> GenerateRoomTypes()
    {
        var id = 0;
        foreach (var type in Enum.GetValues(typeof(RoomTypeEnums)))
        {
            id += 1;
            RoomTypes.Add(new RoomType((RoomTypeEnums)type) { Id = id });
        }
        return RoomTypes;
    }
}