using Skeppsgarden.Data.Models.Enums;
using Skeppsgarden.Data.Models.Types;

namespace Skeppsgarden.Data.EnumSeeders;

public class FacilityTypesSeeder
{
    public readonly ICollection<FacilityType> FacilityTypes;
    
    public FacilityTypesSeeder()
    {
        FacilityTypes = new List<FacilityType>();
        FacilityTypes = GenerateFacilityTypes();
    }
    
    private ICollection<FacilityType> GenerateFacilityTypes()
    {
        var id = 0;
        foreach (var type in Enum.GetValues(typeof(FacilityTypeEnums)))
        {
            id += 1;
            FacilityTypes.Add(new FacilityType((FacilityTypeEnums)type) { Id = id });
        }
        return FacilityTypes;
    }
}