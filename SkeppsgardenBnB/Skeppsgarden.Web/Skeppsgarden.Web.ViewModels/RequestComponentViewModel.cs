namespace Skeppsgarden.Web.ViewModels;

public class RequestComponentViewModel
{
    public int Count { get; set; }
    
    public List<SingleRequestViewModel> Requests { get; set; }
}

public class SingleRequestViewModel
{
    public DateTime Date { get; set; }
}

