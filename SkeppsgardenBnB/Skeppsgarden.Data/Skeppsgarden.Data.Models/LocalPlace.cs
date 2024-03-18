using EasyData.EntityFrameworkCore;

namespace Skeppsgarden.Data.Models;

using System.ComponentModel.DataAnnotations;
using static Common.Constants.DatabaseEntitiesValidationConstants.LocalPlaceConstants;

[MetaEntity(false)]
public class LocalPlace
{
    public int Id { get; set; }

    [Required]
    [MaxLength(NameMaxLength)]
    public string Name { get; set; } = null!;
    
    [Required]
    [MaxLength(DescriptionMaxLength)]
    public string Description { get; set; } = null!;
    
    [Required]
    [MaxLength(UrlMaxLength)]
    public string Url { get; set; } = null!;
    
    [Required]
    [MaxLength(ImageUrlMaxLength)]
    public string ImageUrl { get; set; } = null!;
    
}