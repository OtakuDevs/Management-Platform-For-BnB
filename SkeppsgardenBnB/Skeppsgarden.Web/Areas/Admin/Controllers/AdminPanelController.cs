using System.Diagnostics;
using ImageHelper.Services;
using MailProvider.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Skeppsgarden.Data.Models;
using Skeppsgarden.Web.Areas.Admin.Services.Interfaces;
using Skeppsgarden.Web.Areas.Admin.ViewModels;
using Skeppsgarden.Web.Areas.Admin.ViewModels.FormModels;
using Skeppsgarden.Web.ViewModels;
using X.PagedList;
using static Skeppsgarden.Common.Constants.GeneralApplicationConstants;

namespace Skeppsgarden.Web.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = AdministratorRoleName)]
[AutoValidateAntiforgeryToken]
public class AdminPanelController : Controller
{
    private readonly IAdminActionsService _adminActionsService;
    private readonly IEmailSender _emailSender;
    private readonly IFileUploadService _fileUploadService;

    public AdminPanelController(IAdminActionsService adminActionsService,
        IEmailSender emailSender, IFileUploadService fileUploadService)
    {
        _adminActionsService = adminActionsService;
        _emailSender = emailSender;
        _fileUploadService = fileUploadService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var statusMessage = TempData["StatusMessage"] as string;

        if (!string.IsNullOrEmpty(statusMessage))
        {
            ViewBag.StatusMessage = statusMessage;
        }

        return View();
    }

    [HttpGet]
    public async Task<IActionResult> RequestedRooms(int? page)
    {
        var model = await _adminActionsService.GetRequestedRoomsAsync();

        int pageNumber = page ?? DefaultStartPagePagination;
        int entitiesPerPage = DefaultListEntitiesPerPage;

        var totalNumberOfModelItems = model.Requests.Count();
        var totalPages = (int)Math.Ceiling((double)totalNumberOfModelItems / entitiesPerPage);
        if (pageNumber > totalPages)
        {
            pageNumber = 1;
        }

        var pagedRequests = model.Requests.ToPagedList(pageNumber, entitiesPerPage);

        return PartialView("_RequestedRoomsPartial", pagedRequests);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ConfirmReservation(string id, string discountedPrice, string ownerNotes)
    {
        try
        {
            var request = await _adminActionsService.GetRequestByIdAsync(id);

            if (request == null)
            {
                return NotFound();
            }

            var receiver = await _adminActionsService.GetCustomerEmailAsync(id);

            if (receiver == null)
            {
                return NotFound();
            }

            if (string.IsNullOrEmpty(discountedPrice))
            {
                discountedPrice = request.TotalPrice.ToString();
            }

            await _adminActionsService.ConfirmRequestAsync(id, int.Parse(discountedPrice), ownerNotes);

            var customerName = $"{request.Customer.FirstName} {request.Customer.LastName}";

            var subject = $"CONF-RES#{request.SequenceNumber.ToString()} Reservation confirmed - SkeppsgårdenBnB";
            var message = MailProvider.EmailTemplateGenerator.GenerateReservationConfirmationEmail(customerName,
                request.SequenceNumber.ToString(), request.CheckIn.ToString("d"), request.CheckOut.ToString("d"),
                request.NumberOfGuests.ToString(), discountedPrice, ownerNotes);

            await _emailSender.SendEmailAsync(receiver, subject, message);

            return RedirectToAction(nameof(Index), new { area = "Admin" });
        }
        catch (Exception ex)
        {
            return View("Error",
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> RejectReservation(string id, string reason, string ownerNotes)
    {
        var request = await _adminActionsService.GetRequestByIdAsync(id);

        if (request == null)
        {
            return NotFound();
        }

        var receiver = await _adminActionsService.GetCustomerEmailAsync(id);

        if (receiver == null)
        {
            return NotFound();
        }
        
        var customerName = $"{request.Customer.FirstName} {request.Customer.LastName}";
        var subject = $"DEN-RES#{request.SequenceNumber.ToString()} Reservation rejected - SkeppsgårdenBnB";
        var message = MailProvider.EmailTemplateGenerator.GenerateReservationDenialEmail(customerName,
            request.SequenceNumber.ToString(), reason, ownerNotes);

        await _emailSender.SendEmailAsync(receiver, subject, message);

        await _adminActionsService.DeclineRequestAsync(id);

        return RedirectToAction(nameof(Index), new { area = "Admin" });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ArchiveReservation(string id)
    {
        var reservation = await _adminActionsService.GetReservationByIdAsync(id);

        if (reservation == null)
        {
            return NotFound();
        }

        await _adminActionsService.ArchiveReservationAsync(id);

        return RedirectToAction(nameof(Index), new { area = "Admin" });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ArchiveOlderReservations()
    {
        await _adminActionsService.ArchiveOlderReservationsAsync();

        return RedirectToAction(nameof(Index), new { area = "Admin" });
    }

    [HttpGet]
    public async Task<IActionResult> Reservations(int? page)
    {
        var model = await _adminActionsService.GetReservationsAsync();

        int pageNumber = page ?? DefaultStartPagePagination;
        int entitiesPerPage = DefaultListEntitiesPerPage;

        var totalNumberOfModelItems = model.Reservations.Count();
        var totalPages = (int)Math.Ceiling((double)totalNumberOfModelItems / entitiesPerPage);
        if (pageNumber > totalPages)
        {
            pageNumber = 1;
        }

        var pagedReservations = model.Reservations.ToPagedList(pageNumber, entitiesPerPage);
        
        return PartialView("_ReservationsPartial", pagedReservations);
    }

    [HttpGet]
    public async Task<IActionResult> AddReservation()
    {
        var reservation = await _adminActionsService.ReservationGuid(new ReservationFormModel());

        reservation.SequenceNumber = await _adminActionsService.GenerateSequenceNumberAsync();

        reservation.Customers = (await _adminActionsService.GetAllCustomersAsync())
            .Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = $"{c.FirstName} {c.LastName}"
            });

        reservation.Rooms = (await _adminActionsService.GetAllRoomsAsync())
            .Select(r => new SelectListItem
            {
                Value = r.Id.ToString(),
                Text = r.RoomNumber.ToString()
            });

        return View(reservation);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddReservation(ReservationFormModel reservation)
    {
        reservation.NumberOfNights = reservation.CheckOut.Subtract(reservation.CheckIn).Days;

        ModelState.Remove("Customers");
        ModelState.Remove("Rooms");

        if (!ModelState.IsValid)
        {
            var reservationRe = await _adminActionsService.ReservationGuid(new ReservationFormModel());

            reservationRe.SequenceNumber = await _adminActionsService.GenerateSequenceNumberAsync();

            reservationRe.Customers = (await _adminActionsService.GetAllCustomersAsync())
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = $"{c.FirstName} {c.LastName}"
                });
            reservationRe.Rooms = (await _adminActionsService.GetAllRoomsAsync())
                .Select(r => new SelectListItem
                {
                    Value = r.Id.ToString(),
                    Text = r.RoomNumber.ToString()
                });

            return View(reservationRe);
        }

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

        await _adminActionsService.AddReservationAsync(newReservation);

        return RedirectToAction(nameof(Index), new { area = "Admin" });
    }

    [HttpPost]
    public async Task<JsonResult> CreateNewCustomer([FromBody] Customer customer)
    {
        try
        {
            await _adminActionsService.AddCustomerAsync(customer);

            return Json(new { customer = customer });
        }
        catch (Exception ex)
        {
            return Json(new { error = ex.Message });
        }
    }

    [HttpGet]
    public async Task<IActionResult> Events(int? page)
    {
        var model = await _adminActionsService.GetEventsAsync();

        int pageNumber = page ?? DefaultStartPagePagination;
        int entitiesPerPage = DefaultListEntitiesPerPage;

        var totalNumberOfModelItems = model.Events.Count();
        var totalPages = (int)Math.Ceiling((double)totalNumberOfModelItems / entitiesPerPage);
        if (pageNumber > totalPages)
        {
            pageNumber = 1;
        }

        var pagedEvents = model.Events.ToPagedList(pageNumber, entitiesPerPage);
        
        return PartialView("_EventsPartial", pagedEvents);
    }

    [HttpGet]
    public async Task<IActionResult> AddEvent()
    {
        var eventModel = new EventFormModel();

        return View(eventModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddEvent(EventFormModel eventModel, IFormFile file)
    {
        if (!ModelState.IsValid)
        {
            return View(eventModel);
        }

        try
        {
            var path = await _fileUploadService.UploadFile(file);

            if (string.IsNullOrEmpty(path))
            {
                ModelState.AddModelError("path", "Please select a file (only images are supported) to upload.");
            }

            if (!ModelState.IsValid)
            {
                System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "events",
                    Path.GetFileName(path)));
                return View(eventModel);
            }

            var newEvent = new Event()
            {
                Id = eventModel.Id,
                Title = eventModel.Title,
                Start = eventModel.Start.ToUniversalTime(),
                End = eventModel.End.ToUniversalTime(),
                Description = eventModel.Description,
                Location = eventModel.Location,
                Image = path
            };

            await _adminActionsService.AddEventAsync(newEvent);

            TempData["Success"] = "Your event and picture were uploaded successfully!";
            return RedirectToAction(nameof(Index), new { area = "Admin" });
        }
        catch (Exception)
        {
            return View(eventModel);
        }
    }

    [HttpGet]
    public async Task<IActionResult> EditEvent(string id)
    {
        var eventModel = await _adminActionsService.GetEventByIdAsync(id);

        if (eventModel == null)
        {
            return NotFound();
        }

        return View(eventModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditEvent(EventFormModel eventModel, IFormFile? file)
    {
        ModelState.Remove("file");
        if (!ModelState.IsValid)
        {
            return View(eventModel);
        }

        var eventToEdit = await _adminActionsService.GetEventByIdAsync(eventModel.Id.ToString());

        try
        {
            if (file == null && string.IsNullOrEmpty(eventToEdit.Image))
            {
                ModelState.AddModelError("file", "Please select a file to upload.");
                return View(eventModel);
            }

            if (file == null && !string.IsNullOrEmpty(eventToEdit.Image))
            {
                eventModel.Image = eventToEdit.Image;
            }

            if (file != null)
            {
                var path = await _fileUploadService.UploadFile(file);

                if (!string.IsNullOrEmpty(eventModel.Image))
                {
                    System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images",
                        "events",
                        Path.GetFileName(eventModel.Image)));
                }

                eventModel.Image = path;
            }

            await _adminActionsService.EditEventAsync(eventModel);

            TempData["Success"] = "Your event and picture were edited successfully!";
            return RedirectToAction(nameof(Index), new { area = "Admin" });
        }
        catch (Exception)
        {
            return View(eventModel);
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteEvent(string id)
    {
        var @event = await _adminActionsService.GetEventByIdToDeleteAsync(Guid.Parse(id));

        if (@event == null)
        {
            return NotFound();
        }

        System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "events",
            Path.GetFileName(@event.Image)));

        await _adminActionsService.DeleteEventAsync(@event);

        TempData["Success"] = "Your event and picture were deleted successfully!";
        return RedirectToAction(nameof(Index), new { area = "Admin" });
    }

    [HttpGet]
    public async Task<IActionResult> Hyperlinks()
    {
        var model = await _adminActionsService.GetHyperlinksAsync();

        return PartialView("_HyperlinksPartial", model);
    }

    [HttpGet]
    public async Task<IActionResult> BlockRoom()
    {
        var model = new RoomListViewModel();
        
        var rooms = await _adminActionsService.GetAllRoomsAsync();
        var enumerable = rooms as Room[] ?? rooms.ToArray();
        var roomView = enumerable
            .Select(r => new RoomViewModel
            {
                Id = r.Id,
                RoomNumber = r.RoomNumber,
                BlockedDates = r.BlockedDates
                    .Select(b => new RoomBlockedDatesViewModel
                    {
                        Id = b.Id,
                        StartDate = b.StartDate,
                        EndDate = b.EndDate,
                        Reason = b.Reason
                    })
                    .ToList()
            })
            .ToList();

        model.Rooms = roomView.OrderBy(r => r.RoomNumber).ToList();

        return PartialView("_BlockRoomPartial", model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> BlockRoom(string id, string startDate, string endDate, string reason,
        RoomListViewModel model)
    {
        var room = await _adminActionsService.GetAllRoomsAsync();

        var roomToBlock = room.FirstOrDefault(r => r.Id == Guid.Parse(id));

        if (roomToBlock == null)
        {
            return NotFound();
        }

        var isBlocked = await _adminActionsService
            .BlockRoomForDatesAsync(roomToBlock.Id, DateTime.Parse(startDate),
                DateTime.Parse(endDate), reason);

        if (!isBlocked)
        {
            ModelState.AddModelError("", "Room is already blocked for the selected dates.");
            return PartialView("_BlockRoomPartial", model);
        }

        TempData["Success"] = "Room was blocked successfully!";
        return RedirectToAction(nameof(Index), new { area = "Admin" });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteBlockedDate(string roomId, string blockedDateId)
    {
        var room = await _adminActionsService.GetAllRoomsAsync();

        var roomToUnblock = room.FirstOrDefault(r => r.Id == Guid.Parse(roomId));

        if (roomToUnblock == null)
        {
            return NotFound();
        }

        var isUnblocked =
            await _adminActionsService.RemoveBlockedDatesAsync(roomToUnblock.Id, Guid.Parse(blockedDateId));

        if (!isUnblocked)
        {
            ModelState.AddModelError("", "Room is already unblocked.");
            return RedirectToAction(nameof(Index), new { area = "Admin" });
        }

        TempData["Success"] = "Room was unblocked successfully!";
        return RedirectToAction(nameof(Index), new { area = "Admin" });
    }

    [HttpGet]
    public IActionResult ExcelDownload()
    {
        var tableNames = _adminActionsService.GetTableNames();
        return PartialView("_ExcelDownloadPartial", tableNames);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult ExcelDownload(List<string> selectedTables)
    {
        if (selectedTables == null || !selectedTables.Any())
        {
            TempData["StatusMessage"] = "No tables selected for download.";
            return RedirectToAction("Index");
        }

        try
        {
            Dictionary<string, List<object>> tableDataDictionary = new Dictionary<string, List<object>>();

            foreach (var tableName in selectedTables)
            {
                List<object> tableData = _adminActionsService.GetTableData(tableName);

                tableDataDictionary.Add(tableName, tableData);
            }

            byte[] fileContents = _adminActionsService.GenerateMultiTableExcelFile(tableDataDictionary);

            var currentDate = DateTime.Now.ToString("yyyyMMdd");
            var fileName = $"Database_excerpt_{currentDate}.xlsx";

            TempData["DownloadSuccess"] = "Excel file downloaded successfully.";
            return File(fileContents, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileName);
        }
        catch (Exception)
        {
            TempData["DownloadError"] = "Error occurred during Excel file generation.";

            return RedirectToAction("Index");
        }
    }
}