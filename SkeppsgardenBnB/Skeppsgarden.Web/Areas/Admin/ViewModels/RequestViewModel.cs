namespace Skeppsgarden.Web.Areas.Admin.ViewModels;

public class RequestViewModel
{
    public string Id { get; set; }
    
    public int SequenceNumber { get; set; }
    
    public string CustomerId { get; set; } = null!;
    
    public string CustomerName { get; set; } = null!;
    
    public string CustomerEmail { get; set; } = null!;
    
    public int Room { get; set; }
    
    public int NumberOfGuests { get; set; }
    
    public int NumberOfNights { get; set; }
    
    public int TotalPrice { get; set; }
    
    public DateTime CheckIn { get; set; }
    
    public DateTime CheckOut { get; set; }
    
    //Arrival time
    public TimeSpan? CheckInTime { get; set; }
    
    public string? SpecialRequirements { get; set; }
    
    public bool IsConfirmed { get; set; }
    
}