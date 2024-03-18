namespace Skeppsgarden.Web.Areas.Admin.ViewModels.Calendar;

public class ConfirmedReservationViewModel
{
    public string Id { get; set; } // ReservationId
    
    public string CustomerName { get; set; }
    
    public string CustomerEmail { get; set; }
    
    public string CustomerPhoneNumber { get; set; }
    
    public string RoomName { get; set; }
    
    public string StartDate { get; set; }
    
    public string EndDate { get; set; }
}