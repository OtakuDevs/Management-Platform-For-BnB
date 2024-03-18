using Skeppsgarden.Data.Models;
using Skeppsgarden.Web.Areas.Admin.ViewModels.Calendar;

namespace Skeppsgarden.Web.Areas.Admin.Services.Interfaces;

public interface ICalendarAdminService
{
    Task<IEnumerable<ConfirmedReservationViewModel>> GetCurrentBookings();
}