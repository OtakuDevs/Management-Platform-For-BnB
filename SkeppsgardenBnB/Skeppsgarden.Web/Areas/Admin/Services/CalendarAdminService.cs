using Microsoft.EntityFrameworkCore;
using Skeppsgarden.Data;
using Skeppsgarden.Data.Models;
using Skeppsgarden.Web.Areas.Admin.Services.Interfaces;
using Skeppsgarden.Web.Areas.Admin.ViewModels.Calendar;

namespace Skeppsgarden.Web.Areas.Admin.Services;

public class CalendarAdminService : ICalendarAdminService
{
    private readonly ApplicationDbContext _data;
    
    public CalendarAdminService(ApplicationDbContext data)
    {
        _data = data;
    }
    
    public async Task<IEnumerable<ConfirmedReservationViewModel>> GetCurrentBookings()
    {
        var bookings = await _data.Reservations
            .Include(r => r.Customer)
            .Include(r => r.Room)
            .ToListAsync();
        
        var calendarBookings = MapBookingsToViewModels(bookings);

        return calendarBookings;
    }
    
    private List<ConfirmedReservationViewModel> MapBookingsToViewModels(IEnumerable<Reservation> bookings)
    {
        var viewModels = new List<ConfirmedReservationViewModel>();
        
        foreach (var booking in bookings)
        {
            var viewModel = new ConfirmedReservationViewModel
            {
                Id = booking.Id.ToString(),
                CustomerName = $"{booking.Customer.FirstName} {booking.Customer.LastName}",
                CustomerEmail = booking.Customer.Email,
                CustomerPhoneNumber = booking.Customer.PhoneNumber,
                RoomName = $"Room num: {booking.Room.RoomNumber}",
                StartDate = booking.CheckIn.ToString("yyyy-MM-dd"),
                EndDate = booking.CheckOut.ToString("yyyy-MM-dd")
            };
            
            viewModels.Add(viewModel);
        }

        return viewModels;
    }
    
}