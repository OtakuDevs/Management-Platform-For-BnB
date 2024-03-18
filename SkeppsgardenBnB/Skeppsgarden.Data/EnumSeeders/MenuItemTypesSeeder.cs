using Skeppsgarden.Data.Models;
using Skeppsgarden.Data.Models.Enums;
using Skeppsgarden.Data.Models.Types;

namespace Skeppsgarden.Data.EnumSeeders;

public class MenuItemTypesSeeder
{
    public readonly ICollection<MenuItemType> MenuItemTypes;
    
    public MenuItemTypesSeeder()
    {
        MenuItemTypes = new List<MenuItemType>();
        MenuItemTypes = GenerateMenuItemTypes();
    }
    
    private ICollection<MenuItemType> GenerateMenuItemTypes()
    {
        var id = 0;
        foreach (var type in Enum.GetValues(typeof(MenuItemTypeEnums)))
        {
            id += 1;
            MenuItemTypes.Add(new MenuItemType((MenuItemTypeEnums)type) { Id = id });
        }
        return MenuItemTypes;
    }
}