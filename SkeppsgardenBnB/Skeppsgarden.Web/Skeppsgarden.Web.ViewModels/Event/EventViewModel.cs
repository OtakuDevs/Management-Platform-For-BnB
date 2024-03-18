namespace Skeppsgarden.Web.ViewModels.Event;

public class EventViewModel
{
    public string Id { get; set; } = null!;
    
    public string Title { get; set; } = null!;
    
    public DateTime Start { get; set; }
    
    public DateTime End { get; set; }
    
    public string Description { get; set; } = null!;
    
    public string Location { get; set; } = null!;
    
    public string? Image { get; set; }
    
    public bool IsInPast {get; set;}
}