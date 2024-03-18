namespace Skeppsgarden.Web.Areas.Admin.ViewModels;

public class EventsListViewModel
{
    public ICollection<EventViewModel> Events { get; set; } = new List<EventViewModel>();
}