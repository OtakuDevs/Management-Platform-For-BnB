
using Skeppsgarden.Data.Models;
using Skeppsgarden.Web.ViewModels.Booking;

namespace Skeppsgarden.Services.Data.Interfaces;

public interface IBookingService
{
    
    Task<AvailableRoomsViewModel> GetAvailableRooms(string checkin, string checkout, string numberOfPeople);

    Task<RequestRoom?> BookRoomAsync(string checkin, string checkout, string numberOfPeople, string id,
        string firstName, string lastName, string email, string phoneNumber, string notes, string checkInTime);
}