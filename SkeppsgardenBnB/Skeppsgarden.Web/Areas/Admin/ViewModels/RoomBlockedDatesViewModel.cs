namespace Skeppsgarden.Web.Areas.Admin.ViewModels;

public class RoomBlockedDatesViewModel
{
    public Guid Id { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string? Reason { get; set; }
    
    public Guid RoomId { get; set; }
}