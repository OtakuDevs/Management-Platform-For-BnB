namespace Skeppsgarden.Web.ViewModels.LocalPlace;

using System.ComponentModel.DataAnnotations;


public class LocalPlacesViewModel
{
    [Required] 
    public string Name { get; set; } = null!;

    [Required] 
    public string Description { get; set; } = null!;

    [Required] 
    public string Url { get; set; } = null!;

    [Required]
    public string ImageUrl { get; set; } = null!;
}