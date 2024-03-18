using System.ComponentModel.DataAnnotations;

namespace Skeppsgarden.Web.Areas.Admin.ViewModels.FormModels;

public class EventFormModel
{
    public EventFormModel()
    {
        Id = Guid.NewGuid();
    }
    
    [Required]
    public Guid Id { get; set; }
    
    [Required]
    public string Title { get; set; } = null!;
    
    [Required]
    public DateTime Start { get; set; }
    
    [Required]
    public DateTime End { get; set; }
    
    [Required]
    public string Description { get; set; } = null!;
    
    [Required]
    public string Location { get; set; } = null!;
    
    public string? Image { get; set; }
}