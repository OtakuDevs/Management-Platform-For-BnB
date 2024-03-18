using Skeppsgarden.Data.Models.Enums;
using Skeppsgarden.Data.Models.Types;

namespace Skeppsgarden.Data.EnumSeeders;

public class ViewTypesSeeder
{
    public readonly ICollection<ViewType> ViewTypes;
    
    public ViewTypesSeeder()
    {
        ViewTypes = new List<ViewType>();
        ViewTypes = GenerateViewTypes();
    }
    
    private ICollection<ViewType> GenerateViewTypes()
    {
        var id = 0;
        foreach (var type in Enum.GetValues(typeof(ViewTypeEnums)))
        {
            id += 1;
            ViewTypes.Add(new ViewType((ViewTypeEnums)type) { Id = id });
        }
        return ViewTypes;
    }
}