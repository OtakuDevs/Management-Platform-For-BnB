using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using Skeppsgarden.Data;
using Skeppsgarden.Data.Models;
using Skeppsgarden.Services.Data.Interfaces;
using Skeppsgarden.Web.Areas.Admin.Services.Interfaces;
using Skeppsgarden.Web.Areas.Admin.ViewModels;
using Skeppsgarden.Web.Areas.Admin.ViewModels.FormModels;

namespace Skeppsgarden.Web.Areas.Admin.Services;

public class AdminActionsService : IAdminActionsService
{
    private readonly ApplicationDbContext _data;

    public AdminActionsService(ApplicationDbContext data)
    {
        _data = data;
    }

    public async Task<RequestsListViewModel> GetRequestedRoomsAsync()
    {
        var model = new RequestsListViewModel();

        var requests = await _data.Requests
            .Include(c => c.Customer)
            .Include(r => r.Room)
            .Select(r => new RequestViewModel()
            {
                Id = r.Id.ToString(),
                SequenceNumber = r.SequenceNumber,
                CustomerId = r.Customer.Id.ToString(),
                CustomerName = $"{r.Customer.FirstName} {r.Customer.LastName}",
                CustomerEmail = r.Customer.Email,
                Room = r.Room.RoomNumber,
                NumberOfGuests = r.NumberOfGuests,
                NumberOfNights = r.NumberOfNights,
                TotalPrice = r.TotalPrice,
                CheckIn = r.CheckIn,
                CheckOut = r.CheckOut,
                CheckInTime = r.CheckInTime,
                SpecialRequirements = r.SpecialRequirements,
                IsConfirmed = r.IsConfirmed,
                
            })
            .OrderBy(r => r.CheckIn)
            .ToListAsync();

        model.Requests = requests;

        return model;
    }

    public async Task<RequestRoom?> GetRequestByIdAsync(string id)
    {
        var request = await _data.Requests.FindAsync(Guid.Parse(id));

        return request;
    }

    public async Task ConfirmRequestAsync(string id, int totalPrice, string ownerNotes)
    {
        var request = await GetRequestByIdAsync(id);
        var room = await _data.Rooms.FindAsync(request.RoomId);

        var currentBookings = await _data.Reservations
            .Where(r => r.RoomId == request.RoomId)
            .Where(r => r.CheckIn <= request.CheckOut && r.CheckOut >= request.CheckIn)
            .ToListAsync();

        if (currentBookings.Any())
        {
            throw new InvalidOperationException("Booking conflict for the same room");
        }
        else
        {
            request.IsConfirmed = true;

            var reservation = new Reservation()
            {
                CustomerId = request.CustomerId,
                SequenceNumber = request.SequenceNumber,
                RoomId = request.RoomId,
                NumberOfGuests = request.NumberOfGuests,
                NumberOfNights = request.NumberOfNights,
                TotalPrice = totalPrice,
                CheckIn = request.CheckIn,
                CheckOut = request.CheckOut,
                CheckInTime = request.CheckInTime,
                SpecialRequirements = request.SpecialRequirements,
                NotesToCustomer = ownerNotes,
            };
            

            await _data.Reservations.AddAsync(reservation);
            _data.Requests.Remove(request);

            await _data.SaveChangesAsync();
        }
    }

    public Task DeclineRequestAsync(string id)
    {
        var request = GetRequestByIdAsync(id);

        _data.Requests.Remove(request.Result);

        return _data.SaveChangesAsync();
    }

    public async Task<ReservationsListViewModel> GetReservationsAsync()
    {
        var model = new ReservationsListViewModel();

        var reservations = await _data.Reservations
            .Include(c => c.Customer)
            .Include(r => r.Room)
            .Select(x => new ReservationViewModel()
            {
                Id = x.Id.ToString(),
                SequenceNumber = x.SequenceNumber,
                CustomerId = x.Customer.Id.ToString(),
                CustomerName = $"{x.Customer.FirstName} {x.Customer.LastName}",
                CustomerEmail = x.Customer.Email,
                Room = x.Room.RoomNumber,
                NumberOfGuests = x.NumberOfGuests,
                NumberOfNights = x.NumberOfNights,
                TotalPrice = x.TotalPrice,
                CheckIn = x.CheckIn,
                CheckOut = x.CheckOut,
                CheckInTime = x.CheckInTime,
                SpecialRequirements = x.SpecialRequirements,
                NotesToCustomer = x.NotesToCustomer,
            })
            .OrderBy(x => x.CheckIn)
            .ToListAsync();

        model.Reservations = reservations;

        return model;
    }

    public async Task ArchiveOlderReservationsAsync()
    {
        var reservations = await _data.Reservations
            .Include(c => c.Customer)
            .Include(r => r.Room)
            .Select(x => new ReservationViewModel()
            {
                Id = x.Id.ToString(),
                SequenceNumber = x.SequenceNumber,
                CustomerId = x.Customer.Id.ToString(),
                CustomerName = $"{x.Customer.FirstName} {x.Customer.LastName}",
                CustomerEmail = x.Customer.Email,
                Room = x.Room.RoomNumber,
                NumberOfGuests = x.NumberOfGuests,
                NumberOfNights = x.NumberOfNights,
                TotalPrice = x.TotalPrice,
                CheckIn = x.CheckIn,
                CheckOut = x.CheckOut,
                CheckInTime = x.CheckInTime,
                SpecialRequirements = x.SpecialRequirements,
                NotesToCustomer = x.NotesToCustomer,
            })
            .ToListAsync();

        var olderReservations = reservations.Where(r => r.CheckOut.AddDays(2) <= DateTime.Now).ToList();

        foreach (var older in olderReservations)
        {
            await ArchiveReservationAsync(older.Id);
        }
    }

    public async Task<string> GetCustomerEmailAsync(string id)
    {
        var request = await _data.Requests.Include(c => c.Customer)
            .FirstOrDefaultAsync(r => r.Id == Guid.Parse(id));

        if (request == null)
        {
            return null;
        }

        var customerEmail = request.Customer.Email;

        return customerEmail;
    }

    public async Task<Reservation> GetReservationByIdAsync(string id)
    {
        var reservation = await _data.Reservations.FindAsync(Guid.Parse(id));

        return reservation;
    }

    public async Task ArchiveReservationAsync(string id)
    {
        var reservation = await GetReservationByIdAsync(id);

        if (reservation == null)
        {
            return;
        }

        _data.Reservations.Remove(reservation);

        var archivedReservation = new HistoricalReservation()
        {
            SequenceNumber = reservation.SequenceNumber,
            CustomerId = reservation.CustomerId,
            RoomId = reservation.RoomId,
            NumberOfGuests = reservation.NumberOfGuests,
            NumberOfNights = reservation.NumberOfNights,
            TotalPrice = reservation.TotalPrice,
            CheckIn = reservation.CheckIn,
            CheckOut = reservation.CheckOut,
            CheckInTime = reservation.CheckInTime,
            SpecialRequirements = reservation.SpecialRequirements,
            NotesToCustomer = reservation.NotesToCustomer,
        };

        _data.HistoricalReservations.Add(archivedReservation);

        await _data.SaveChangesAsync();
    }

    public async Task<int> GenerateSequenceNumberAsync()
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

    public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
    {
        var customers = await _data.Customers.ToListAsync();

        return customers;
    }

    public async Task<IEnumerable<Room>> GetAllRoomsAsync()
    {
        var rooms = await _data.Rooms
            .Include(r => r.BlockedDates)
            .ToListAsync();

        return rooms;
    }

    public async Task<Reservation> AddReservationAsync(Reservation reservation)
    {
        var newReservation = new Reservation()
        {
            Id = reservation.Id,
            SequenceNumber = reservation.SequenceNumber,
            CustomerId = reservation.CustomerId,
            RoomId = reservation.RoomId,
            NumberOfGuests = reservation.NumberOfGuests,
            NumberOfNights = reservation.NumberOfNights,
            TotalPrice = reservation.TotalPrice,
            CheckIn = reservation.CheckIn,
            CheckOut = reservation.CheckOut,
            CheckInTime = reservation.CheckInTime,
            SpecialRequirements = reservation.SpecialRequirements,
            NotesToCustomer = reservation.NotesToCustomer,
        };

        await _data.Reservations.AddAsync(newReservation);

        await _data.SaveChangesAsync();

        return newReservation;
    }

    public async Task AddCustomerAsync(Customer customer)
    {
        await _data.Customers.AddAsync(customer);

        await _data.SaveChangesAsync();
    }

    public async Task<ReservationFormModel> ReservationGuid(ReservationFormModel reservation)
    {
        await Task.Delay(100);

        reservation.Id = Guid.NewGuid();

        return reservation;
    }

    public async Task<EventsListViewModel> GetEventsAsync()
    {
        var model = new EventsListViewModel();

        var events = await _data.Events
            .Select(e => new EventViewModel()
            {
                Id = e.Id.ToString(),
                Title = e.Title,
                Description = e.Description,
                Start = e.Start,
                End = e.End,
                Location = e.Location,
                Image = e.Image,
            })
            .ToListAsync();

        model.Events = events;

        return model;
    }

    public async Task AddEventAsync(Event @event)
    {
        await _data.Events.AddAsync(@event);

        await _data.SaveChangesAsync();
    }

    public async Task<EventFormModel> GetEventByIdAsync(string id)
    {
        var @event = await _data.Events.FindAsync(Guid.Parse(id));

        if (@event != null)
        {
            EventFormModel eventFormModel = new()
            {
                Id = @event.Id,
                Title = @event.Title,
                Description = @event.Description,
                Start = @event.Start,
                End = @event.End,
                Location = @event.Location,
                Image = @event.Image,
            };
            return eventFormModel;
        }

        return null;
    }

    public async Task EditEventAsync(EventFormModel @event)
    {
        var eventToEdit = await _data.Events.FindAsync(@event.Id);

        if (eventToEdit == null)
        {
            return;
        }

        eventToEdit.Title = @event.Title;
        eventToEdit.Start = DateTime.SpecifyKind(@event.Start, DateTimeKind.Utc);
        eventToEdit.End = DateTime.SpecifyKind(@event.End, DateTimeKind.Utc);
        eventToEdit.Description = @event.Description;
        eventToEdit.Location = @event.Location;
        eventToEdit.Image = @event.Image;

        await _data.SaveChangesAsync();
    }

    public async Task<Event> GetEventByIdToDeleteAsync(Guid id)
    {
        var @event = await _data.Events.FindAsync(id);

        return @event;
    }

    public async Task DeleteEventAsync(Event @event)
    {
        if (@event == null)
        {
            return;
        }

        _data.Events.Remove(@event);

        await _data.SaveChangesAsync();
    }

    public async Task<HyperlinkListViewModel> GetHyperlinksAsync()
    {
        var model = new HyperlinkListViewModel();

        var hyperlinks = await _data.Hyperlinks
            .Select(h => new HyperlinkViewModel()
            {
                Text = h.Text,
                Url = h.Url,
            })
            .ToListAsync();

        model.Hyperlinks = hyperlinks;

        return model;
    }

    public async Task<bool> BlockRoomForDatesAsync(Guid roomId, DateTime startDate, DateTime endDate, string reason)
    {
        var room = await _data.Rooms.Include(r => r.BlockedDates).FirstOrDefaultAsync(r => r.Id == roomId);

        if (room != null)
        {
            if (room.BlockedDates.Any(b => startDate <= b.EndDate && endDate >= b.StartDate))
            {
                return false; // Room is already blocked for these dates
            }

            var blockedDate = new BlockedDate
            {
                StartDate = startDate,
                EndDate = endDate,
                Reason = reason,
                RoomId = roomId
            };

            room.BlockedDates.Add(blockedDate);

            _data.BlockedDates.Add(blockedDate);

            await _data.SaveChangesAsync();

            return true;
        }

        return false;
    }

    public async Task<bool> RemoveBlockedDatesAsync(Guid roomId, Guid blockedDateId)
    {
        var blockedDates =
            await _data.BlockedDates.FirstOrDefaultAsync(b => b.Id == blockedDateId && b.RoomId == roomId);
        if (blockedDates == null)
            return false;

        _data.BlockedDates.Remove(blockedDates);
        await _data.SaveChangesAsync();

        return true;
    }

    public List<string> GetTableNames()
    {
        var tableNames = new List<string>();

        var tables = _data.Model.GetEntityTypes();

        foreach (var table in tables)
        {
            if (!table.GetTableName()!.Contains("AspNet"))
            {
                tableNames.Add(table.GetTableName());
            }
        }

        return tableNames;
    }

    public byte[] GenerateMultiTableExcelFile(Dictionary<string, List<object>> tableDataDictionary)
    {
        using (var package = new ExcelPackage())
        {
            foreach (var kvp in tableDataDictionary)
            {
                var tableName = kvp.Key;
                var tableData = kvp.Value;

                var worksheet = package.Workbook.Worksheets.Add(tableName);

                // Add header row
                var objectType = tableData.FirstOrDefault()?.GetType();
                if (objectType != null)
                {
                    var properties = objectType.GetProperties();
                    for (int i = 0; i < properties.Length; i++)
                    {
                        worksheet.Cells[1, i + 1].Value = properties[i].Name;
                    }

                    // Add data rows
                    int row = 2;
                    foreach (var item in tableData)
                    {
                        for (int i = 0; i < properties.Length; i++)
                        {
                            var propertyValue = properties[i].GetValue(item);
                            if (propertyValue == null)
                            {
                                continue;
                            }

                            var propertyType = propertyValue!.GetType();
                            
                            if (propertyType.Name == "Customer")
                            {
                                var props = propertyValue.GetType().GetProperties();
                                var firstName = props[1];
                                var lastName = props[2];
                                var email = props[3];
                                var propValue = $"{firstName.GetValue(propertyValue)} {lastName.GetValue(propertyValue)} ({email.GetValue(propertyValue)})";
                                worksheet.Cells[row, i + 1].Value = propValue;
                            }
                            else if (propertyType.Name == "Room")
                            {
                                var props = propertyValue.GetType().GetProperties();
                                var roomNumber = props[1];
                                var propValue = roomNumber.GetValue(propertyValue);
                                worksheet.Cells[row, i + 1].Value = propValue;
                            }
                            // Check if the property is of type DateTime
                            else if (propertyValue is DateTime dateTimeValue)
                            {
                                worksheet.Cells[row, i + 1].Value = dateTimeValue;
                                worksheet.Cells[row, i + 1].Style.Numberformat.Format = "yyyy-MM-dd";
                            }
                            else if (propertyValue is TimeSpan timeSpanValue)
                            {
                                worksheet.Cells[row, i + 1].Value = timeSpanValue;
                                worksheet.Cells[row, i + 1].Style.Numberformat.Format = "HH:mm";
                            }
                            else
                            {
                                worksheet.Cells[row, i + 1].Value = propertyValue;
                            }
                        }

                        row++;
                    }
                }
            }

            // Save the Excel package to a memory stream
            using (var memoryStream = new MemoryStream())
            {
                package.SaveAs(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }


    public List<object> GetTableData(string tableName)
    {
        switch (tableName)
        {
            case "BedTypes":
                return _data.BedTypes.ToList().Cast<object>().ToList();

            case "FacilityTypes":
                return _data.FacilityTypes.ToList().Cast<object>().ToList();

            case "MenuItemTypes":
                return _data.MenuItemsTypes.ToList().Cast<object>().ToList();

            case "RoomTypes":
                return _data.RoomTypes.ToList().Cast<object>().ToList();

            case "UtilityTypes":
                return _data.UtilityTypes.ToList().Cast<object>().ToList();

            case "ViewTypes":
                return _data.ViewTypes.ToList().Cast<object>().ToList();

            case "Customers":
                return _data.Customers.ToList().Cast<object>().ToList();

            case "Events":
                return _data.Events.ToList().Cast<object>().ToList();

            case "Hyperlinks":
                return _data.Hyperlinks.ToList().Cast<object>().ToList();

            case "MenuItems":
                return _data.MenuItems.ToList().Cast<object>().ToList();

            case "RequestRooms":
                return _data.Requests.Include(req => req.Customer).Include(req => req.Room).ToList().Cast<object>()
                    .ToList();

            case "Reservations":
                return _data.Reservations.Include(r => r.Customer).Include(r => r.Room).ToList().Cast<object>()
                    .ToList();

            case "HistoricalReservations":
                return _data.HistoricalReservations.Include(his => his.Customer).Include(his => his.Room).ToList()
                    .Cast<object>().ToList();

            case "Restaurants":
                return _data.Restaurants.ToList().Cast<object>().ToList();

            case "Rooms":
                return _data.Rooms.ToList().Cast<object>().ToList();

            case "LocalPlaces":
                return _data.LocalPlaces.ToList().Cast<object>().ToList();

            case "Activities":
                return _data.Activities.ToList().Cast<object>().ToList();

            case "RoomsFacilityTypes":
                return _data.RoomsFacilityTypes.ToList().Cast<object>().ToList();

            case "RoomsUtilityTypes":
                return _data.RoomsUtilityTypes.ToList().Cast<object>().ToList();

            case "BlockedDates":
                return _data.BlockedDates.Include(bd => bd.Room).ToList().Cast<object>().ToList();

            default:
                return new List<object>();
        }
    }
}