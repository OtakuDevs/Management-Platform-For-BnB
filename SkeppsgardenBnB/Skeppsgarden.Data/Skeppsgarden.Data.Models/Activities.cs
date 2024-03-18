using System.ComponentModel.DataAnnotations;
using EasyData.EntityFrameworkCore;
using static Skeppsgarden.Common.Constants.DatabaseEntitiesValidationConstants.ActivitiesConstants;

namespace Skeppsgarden.Data.Models;

[MetaEntity(false)]
public class Activities
{
    public int Id { get; set; }

    [Required]
    [MaxLength(NameMaxLength)]
    public string Name { get; set; } = null!;
    
    [MaxLength(DescriptionMaxLength)]
    public string? Description { get; set; }
    
    [MaxLength(UrlMaxLength)]
    public string? Url { get; set; }
    
    [Required]
    [MaxLength(ImageUrlMaxLength)]
    public string ImageUrl { get; set; } = null!;
}