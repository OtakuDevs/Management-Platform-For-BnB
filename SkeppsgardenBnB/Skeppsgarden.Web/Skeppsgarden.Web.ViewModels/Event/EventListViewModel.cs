namespace Skeppsgarden.Web.ViewModels.Event;

public class EventListViewModel
{
    public ICollection<EventViewModel> Events { get; set; } = new List<EventViewModel>();
}