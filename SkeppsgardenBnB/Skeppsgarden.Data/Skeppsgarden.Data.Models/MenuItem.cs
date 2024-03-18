using System.ComponentModel.DataAnnotations.Schema;
using EasyData.EntityFrameworkCore;
using Skeppsgarden.Data.Models.Enums;
using Skeppsgarden.Data.Models.Types;

namespace Skeppsgarden.Data.Models;

using System.ComponentModel.DataAnnotations;
using static Common.Constants.DatabaseEntitiesValidationConstants.MenuItemConstants;

public class MenuItem
{
    public MenuItem()
    {
        Id = Guid.NewGuid();
    }
    
    [MetaEntityAttr(ShowOnView = false)]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(NameMaxLength)]
    [Display(Name = "Item Name")]
    public string Name { get; set; } = null!;
    
    [Required]
    [ForeignKey(nameof(MenuItemType))]
    [Display(Name = "Type")]
    public int MenuItemTypeId { get; set; }

    [Required]
    public MenuItemType MenuItemType { get; set; } = null!;
    
    [Required]
    [MaxLength(IngredientsMaxLength)]
    public string Ingredients { get; set; } = null!;
    
    [Required]
    public int Price { get; set; }
    
    [Required]
    [ForeignKey(nameof(Restaurant))]
    [Display(Name = "Restaurant Connection")]
    public Guid RestaurantId { get; set; }
    
    public Restaurant Restaurant { get; set; } = null!;
    
}