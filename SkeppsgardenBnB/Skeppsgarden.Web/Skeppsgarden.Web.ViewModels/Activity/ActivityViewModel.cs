using System.ComponentModel.DataAnnotations;

namespace Skeppsgarden.Web.ViewModels.Activity;

public class ActivityViewModel
{
    [Required] 
    public string Name { get; set; } = null!;
    
    public string Description { get; set; } = null!;
    
    public string Url { get; set; } = null!;

    [Required]
    public string ImageUrl { get; set; } = null!;
}