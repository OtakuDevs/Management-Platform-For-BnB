namespace Skeppsgarden.Web.Areas.Admin.ViewModels;

public class RoomViewModel
{
    public Guid Id { get; set; }
    
    public int RoomNumber { get; set; }
    
    public DateTime StartDate { get; set; }
    
    public DateTime EndDate { get; set; }
    
    public List<RoomBlockedDatesViewModel> BlockedDates { get; set; }
}