namespace Skeppsgarden.Web.Areas.Admin.ViewModels;

public class RequestsListViewModel
{
    public ICollection<RequestViewModel> Requests { get; set; } = new List<RequestViewModel>();
}
