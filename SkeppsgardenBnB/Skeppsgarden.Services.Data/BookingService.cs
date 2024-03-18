using Azure.Core;
using Calculator;
using MailProvider;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Skeppsgarden.Data;
using Skeppsgarden.Data.Models;
using Skeppsgarden.Services.Data.Interfaces;
using Skeppsgarden.Web.ViewModels.Booking;
using static Calculator.StayTotalPrice;

namespace Skeppsgarden.Services.Data;

public class BookingService : IBookingService
{
    private readonly ApplicationDbContext _data;
    private readonly MailProvider.Services.Interfaces.IEmailSender _emailSender;

    public BookingService(ApplicationDbContext data, MailProvider.Services.Interfaces.IEmailSender emailSender)
    {
        _data = data;
        _emailSender = emailSender;
    }
    

    public async Task<AvailableRoomsViewModel> GetAvailableRooms(string checkin, string checkout, string numberOfPeople)
    {
        DateTime checkIn = DateTime.Parse(checkin);
        DateTime checkOut = DateTime.Parse(checkout);
        var nights = checkOut.Subtract(checkIn).Days;
        if (String.IsNullOrEmpty(numberOfPeople))
            numberOfPeople = "0";

        var allRooms = await _data.Rooms
            .Include(v => v.ViewType)
            .Include(r => r.RoomType)
            .Include(b => b.BedType)
            .Include(r => r.Reservations)
            .Include(b => b.BlockedDates)
            .Include(ru => ru.RoomsUtilityTypes)
            .Where(c => c.Capacity >= int.Parse(numberOfPeople))
            .ToListAsync();

        foreach (var room in allRooms)
        {
            foreach (var type in room.RoomsUtilityTypes)
            {
                type.UtilityType = await _data.UtilityTypes.FirstOrDefaultAsync(u => u.Id == type.UtilityTypeId);
            }
        }
        var availableRooms = GetAvailableRoomsForDates(allRooms, checkIn, checkOut);

        var roomRequests = _data.Requests.Where(r => r.CheckIn < checkOut && r.CheckOut > checkIn).ToList();
        foreach (var room in roomRequests)
        {
            var requestedRoom = availableRooms.FirstOrDefault(r => r.Id == room.RoomId);
            if (requestedRoom != null)
            {
                requestedRoom.IsRequested = true;
            }
        }
        
        var rooms = availableRooms
            .Select(r => new RequestSingleRoomViewModel()
            {
                Id = r.Id,
                Image = r.Images.Split(", ", StringSplitOptions.RemoveEmptyEntries).First().ToString() + ".jpg",
                RoomNumber = r.RoomNumber,
                Level = "First floor",
                View = r.ViewType.Name,
                RoomType = r.RoomType.Type,
                Areas = r.RoomsUtilityTypes.Any() ? string.Join(" • ", r.RoomsUtilityTypes.Select(rut => rut.UtilityType.Name)) : null,
                Capacity = r.Capacity,
                BedTypes = r.BedType.Name,
                Rate = r.Rate,
                OriginalPrice = r.Rate * nights,
                Nights = nights,
                TotalPrice = CalculateTotalPrice(r.RoomNumber, checkOut.Subtract(checkIn).Days, r.Rate),
                IsRequested = r.IsRequested,
            })
            .OrderBy(r => r.RoomNumber)
            .ToList();

        var model = new AvailableRoomsViewModel()
        {
            CheckIn = checkIn,
            CheckOut = checkOut,
            Rooms = rooms,
            NumberOfPeople = int.Parse(numberOfPeople),
            Customer = new CustomerViewModel()
            {
                FirstName = "",
                LastName = "",
                Email = "",
                PhoneNumber = "",
            },
            SearchPerformed = true,
        };

        return model;
    }

    public async Task<RequestRoom?> BookRoomAsync(string checkin, string checkout, string numberOfPeople, string id,
        string firstName, string lastName, string email, string phoneNumber, string notes, string checkInTime)
    {
        DateTime checkIn = DateTime.Parse(checkin);
        DateTime checkOut = DateTime.Parse(checkout);
        TimeSpan checkInTimeSpan = TimeSpan.Parse(checkInTime);
        

        var people = int.TryParse(numberOfPeople, out var result) ? result : 0;

        if (result == 0)
            return null;

        var customer = await _data.Customers.FirstOrDefaultAsync(c => c.Email == email);
        if (customer == null)
        {
            customer = new Customer()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber,
            };
            await _data.Customers.AddAsync(customer);
        }

        var room = await _data.Rooms.FirstOrDefaultAsync(r => r.Id == Guid.Parse(id));

        var requestRoom = new RequestRoom()
        {
            Customer = customer!,
            CustomerId = customer!.Id,
            Room = room!,
            RoomId = room!.Id,
            NumberOfGuests = people,
            NumberOfNights = checkOut.Subtract(checkIn).Days,
            TotalPrice = CalculateTotalPrice(room.RoomNumber, checkOut.Subtract(checkIn).Days, room.Rate),
            CheckIn = checkIn,
            CheckOut = checkOut,
            CheckInTime = checkInTimeSpan,
            SpecialRequirements = notes,
            IsConfirmed = false,
            SequenceNumber = await GenerateSequenceNumberAsync(),
        };
        
        await _data.Requests.AddAsync(requestRoom);
        await _data.SaveChangesAsync();

        // Send email to customer
        var requestNumber = requestRoom.SequenceNumber.ToString();
        var customerName = $"{customer.FirstName} {customer.LastName}";
        string confirmationEmail;

        // In case of more than 3 nights
        confirmationEmail = requestRoom.TotalPrice > 3200
            ? EmailTemplateGenerator.GenerateReservationRequestConfirmationEmailMoreNights(customerName, requestNumber)
            : EmailTemplateGenerator.GenerateReservationRequestConfirmationEmail(customerName, requestNumber);

        var subject = $"CONF-REQ#{requestNumber} Reservation Request Confirmation";

        await _emailSender.SendEmailAsync(email, subject, confirmationEmail);

        return requestRoom;
    }

    private List<Room> GetAvailableRoomsForDates(List<Room> allRooms, DateTime checkIn, DateTime checkOut)
    {
        var availableRooms = new List<Room>();

        foreach (var room in allRooms)
        {
            if (IsRoomAvailableForDates(room, checkIn, checkOut))
            {
                availableRooms.Add(room);
            }
        }

        return availableRooms;
    }

    private bool IsRoomAvailableForDates(Room room, DateTime checkIn, DateTime checkOut)
    {
        foreach (var reservation in room.Reservations)
        {
            if (checkIn < reservation.CheckOut && checkOut > reservation.CheckIn)
            {
                return false;
            }
        }

        foreach (var blockedDate in room.BlockedDates)
        {
            if (checkIn < blockedDate.EndDate && checkOut > blockedDate.StartDate)
            {
                return false;
            }
        }
        
        return true;
    }

    private async Task<int> GenerateSequenceNumberAsync()
    {
        int startingNumber = 1000;

        // Retrieve the maximum sequence number from the database
        int maxSequenceNumberRequest = await _data.Requests.MaxAsync(r => (int?)r.SequenceNumber) ?? 0;
        int maxSequenceNumberRes = await _data.Reservations.MaxAsync(r => (int?)r.SequenceNumber) ?? 0;
        int maxSequenceNumberHist = await _data.HistoricalReservations.MaxAsync(r => (int?)r.SequenceNumber) ?? 0;

        // Increment the maximum sequence number to generate the next one
        int nextSequenceNumberRequest = maxSequenceNumberRequest + 1;
        int nextSequenceNumberRes = maxSequenceNumberRes + 1;
        int nextSequenceNumberHis = maxSequenceNumberHist + 1;

        var nextSequenceNumber = Math.Max(nextSequenceNumberRes, nextSequenceNumberRequest);
        nextSequenceNumber = Math.Max(nextSequenceNumber, nextSequenceNumberHis);

        nextSequenceNumber = Math.Max(nextSequenceNumber, startingNumber);

        return nextSequenceNumber;
    }
}