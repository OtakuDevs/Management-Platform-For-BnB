using Skeppsgarden.Data.Models;

namespace Skeppsgarden.Web.ViewModels;

public class ResultViewModel
{
    public bool IsSuccess { get; set; }
    
    public string Title { get; set; } = null!;
    
    public string Message { get; set; } = null!;
    
    
    public int OriginalPrice { get; set; }
    
    public int Discount { get; set; }
    
    public RequestRoom Request { get; set; } = null!;
    
    
}