using EasyData.EntityFrameworkCore;

namespace Skeppsgarden.Data.Models;

using System.ComponentModel.DataAnnotations;
using static Common.Constants.DatabaseEntitiesValidationConstants.RestaurantConstants;

[MetaEntity(false)]
public class Restaurant
{
    public Restaurant()
    {
        Id = Guid.NewGuid();
    }
    
    public Guid Id { get; set; }
    
    [Required]
    [MaxLength(DescriptionMaxLength)]
    public string Description { get; set; } = null!;
    
    [MaxLength(ImageUrlMaxLength)]
    public string? Image { get; set; }
    
    public ICollection<MenuItem> MenuItems { get; set; } = new HashSet<MenuItem>();
}