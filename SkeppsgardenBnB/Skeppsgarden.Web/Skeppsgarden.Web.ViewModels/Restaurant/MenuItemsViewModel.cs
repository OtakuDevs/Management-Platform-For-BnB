using Skeppsgarden.Data.Models.Enums;
using Skeppsgarden.Data.Models.Types;

namespace Skeppsgarden.Web.ViewModels.Restaurant;

public class MenuItemsViewModel
{
    public string Name { get; set; } = null!;

    public MenuItemTypeEnums MenuItemType { get; set; }

    public string Ingredients { get; set; } = null!;
    
    public int Price { get; set; }
}