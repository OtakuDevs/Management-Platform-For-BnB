using Skeppsgarden.Data.Models.Enums;
using Skeppsgarden.Data.Models.Types;

namespace Skeppsgarden.Data.EnumSeeders;

public class ExtraTypesSeeder
{
    public readonly ICollection<ExtraType> ExtraTypes;

    public ExtraTypesSeeder()
    {
        ExtraTypes = new List<ExtraType>();
        ExtraTypes = GenerateExtraTypes();
    }

    private ICollection<ExtraType> GenerateExtraTypes()
    {
        var id = 0;
        foreach (var type in Enum.GetValues(typeof(ExtraTypeEnums)))
        {
            id += 1;
            ExtraTypes.Add(new ExtraType((ExtraTypeEnums)type) { Id = id });
        }

        return ExtraTypes;
    }
}