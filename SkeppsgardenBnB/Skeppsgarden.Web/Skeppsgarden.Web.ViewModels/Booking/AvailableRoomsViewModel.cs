namespace Skeppsgarden.Web.ViewModels.Booking;

public class AvailableRoomsViewModel
{
    public DateTime CheckIn { get; set; }
    
    public DateTime CheckOut { get; set; }
    
    public TimeSpan CheckInTime { get; set; }
    
    public int Nights => (CheckOut - CheckIn).Days;
    
    public int NumberOfPeople { get; set; }
    
    public ICollection<RequestSingleRoomViewModel> Rooms { get; set; } = new List<RequestSingleRoomViewModel>();
    
    public CustomerViewModel Customer { get; set; } = null!;
    
    public string SpecialRequirements { get; set; } = null!;
    
    public bool SearchPerformed { get; set; }
    
    public string? Error { get; set; }
}