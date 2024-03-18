using System.ComponentModel.DataAnnotations;
using EasyData.EntityFrameworkCore;
using Skeppsgarden.Data.Models.Enums;
using static Skeppsgarden.Common.Constants.DatabaseEntitiesValidationConstants.MenuItemConstants;

namespace Skeppsgarden.Data.Models.Types;

[MetaEntity(false)]
public class MenuItemType
{
    public MenuItemType()
    {
    }
    
    public MenuItemType(MenuItemTypeEnums typeEnum) : this()
    {
        Type = typeEnum.ToString();
    }
    
    public int Id { get; set; }
    
    [Required]
    [MaxLength(TypeMaxLength)]
    public string Type { get; set; } = null!;
    
    public ICollection<MenuItem> MenuItems { get; set; } = new HashSet<MenuItem>();
}