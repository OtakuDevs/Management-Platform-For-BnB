using Skeppsgarden.Data.Models.Enums;
using Skeppsgarden.Data.Models.Types;

namespace Skeppsgarden.Data.EnumSeeders;

public class BedTypesSeeder
{
    public readonly ICollection<BedType> BedTypes;

    public BedTypesSeeder()
    {
        BedTypes = new List<BedType>();
        BedTypes = GenerateBedTypes();
    }

    private ICollection<BedType> GenerateBedTypes()
    {
        var id = 0;
        foreach (var type in Enum.GetValues(typeof(BedTypeEnums)))
        {
            id += 1;
            BedTypes.Add(new BedType((BedTypeEnums)type) { Id = id });
        }
        return BedTypes;
    }
}