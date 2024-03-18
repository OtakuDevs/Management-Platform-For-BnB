namespace Skeppsgarden.Web.Areas.Admin.ViewModels;

public class ReservationsListViewModel
{
    public ICollection<ReservationViewModel> Reservations { get; set; } = new List<ReservationViewModel>();
}