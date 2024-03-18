using Skeppsgarden.Data.Models;
using Skeppsgarden.Web.Areas.Admin.ViewModels;
using Skeppsgarden.Web.Areas.Admin.ViewModels.FormModels;

namespace Skeppsgarden.Web.Areas.Admin.Services.Interfaces;

public interface IAdminActionsService
{
    Task<RequestsListViewModel> GetRequestedRoomsAsync();

    Task<RequestRoom?> GetRequestByIdAsync(string id);

    Task ConfirmRequestAsync(string id, int totalPrice, string ownerNotes);

    Task DeclineRequestAsync(string id);

    Task<ReservationsListViewModel> GetReservationsAsync();

    Task ArchiveOlderReservationsAsync();

    Task<string> GetCustomerEmailAsync(string id);

    Task<Reservation> GetReservationByIdAsync(string id);

    Task ArchiveReservationAsync(string id);

    Task<int> GenerateSequenceNumberAsync();

    Task<IEnumerable<Customer>> GetAllCustomersAsync();

    Task<IEnumerable<Room>> GetAllRoomsAsync();

    Task<Reservation> AddReservationAsync(Reservation reservation);

    Task AddCustomerAsync(Customer customer);

    Task<ReservationFormModel> ReservationGuid(ReservationFormModel reservation);

    Task<EventsListViewModel> GetEventsAsync();

    Task AddEventAsync(Event @event);

    Task<EventFormModel> GetEventByIdAsync(string id);

    Task EditEventAsync(EventFormModel @event);

    Task<Event> GetEventByIdToDeleteAsync(Guid id);

    Task DeleteEventAsync(Event @event);

    Task<HyperlinkListViewModel> GetHyperlinksAsync();

    Task<bool> BlockRoomForDatesAsync(Guid roomId, DateTime startDate, DateTime endDate, string reason);

    Task<bool> RemoveBlockedDatesAsync(Guid roomId, Guid blockedDateId);

    List<string> GetTableNames();

    byte[] GenerateMultiTableExcelFile(Dictionary<string, List<object>> tableDataDictionary);

    List<object> GetTableData(string tableName);
}