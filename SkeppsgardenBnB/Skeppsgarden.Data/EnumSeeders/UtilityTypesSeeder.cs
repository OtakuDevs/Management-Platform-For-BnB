using Skeppsgarden.Data.Models.Enums;
using Skeppsgarden.Data.Models.Types;

namespace Skeppsgarden.Data.EnumSeeders;

public class UtilityTypesSeeder
{
    public readonly ICollection<UtilityType> UtilityTypes;
    
    public UtilityTypesSeeder()
    {
        UtilityTypes = new List<UtilityType>();
        UtilityTypes = GenerateUtilityTypes();
    }
    
    private ICollection<UtilityType> GenerateUtilityTypes()
    {
        var id = 0;
        foreach (var type in Enum.GetValues(typeof(UtilityTypeEnums)))
        {
            id += 1;
            UtilityTypes.Add(new UtilityType((UtilityTypeEnums)type) { Id = id });
        }
        return UtilityTypes;
    }
}