using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Skeppsgarden.Data;
using Skeppsgarden.Data.Models;
using Skeppsgarden.Services.Data.Interfaces;
using Skeppsgarden.Web.ViewModels;
using Skeppsgarden.Web.ViewModels.Booking;
using Skeppsgarden.Web.ViewModels.Rooms;

namespace Skeppsgarden.Web.Controllers;

public class BookingController : Controller
{
    private readonly IBookingService _bookingService;

    public BookingController(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    public async Task<IActionResult> Index()
    {
        var model = new AvailableRoomsViewModel()
        {
            CheckIn = DateTime.Now,
            CheckOut = DateTime.Now.AddDays(1),
            NumberOfPeople = 0,
            Customer = new CustomerViewModel()
            {
                FirstName = "",
                LastName = "",
                Email = "",
                PhoneNumber = "",
            },
            SearchPerformed = false,
        };

        return View(model);
    }

    public async Task<IActionResult> AvailableRooms(string checkin, string checkout, string numberOfPeople)
    {
        var model = await _bookingService.GetAvailableRooms(checkin, checkout, numberOfPeople);

        return View("Index", model);
    }

    [HttpPost]
    public async Task<IActionResult> BookRoom(string checkin, string checkout, string numberOfPeople, string id,
        string firstName, string lastName, string email, string phoneNumber, string notes, string checkInTime)
    {
        try
        {
            var request = await _bookingService.BookRoomAsync(checkin, checkout, numberOfPeople, id,
                firstName, lastName, email, phoneNumber, notes, checkInTime);

            var room = request?.Room;
            if (request != null)
            {
                // return RedirectToAction("Index", "Home", new { area = "" });
                var result = new ResultViewModel()
                {
                    IsSuccess = true,
                    Title = "Request submitted successfully",
                    Message = "Your booking request has been confirmed. Thank you for choosing us.",
                    Request = request,
                    OriginalPrice = room!.Rate * request.NumberOfNights,
                    Discount = request.Room.Rate * request.NumberOfNights - request.TotalPrice,
                };
                return PartialView("_ResultPartial", result);
            }

            ModelState.AddModelError("", "Booking failed. Please check your input.");
            var model = await _bookingService.GetAvailableRooms(checkin, checkout, numberOfPeople);
            model.Error = "Booking failed. Please check your input.";
            return View("Index", model); // 
        }
        catch (Exception)
        {
            ModelState.AddModelError("", "An error occurred. Please try again later.");
            var model = await _bookingService.GetAvailableRooms(checkin, checkout, numberOfPeople);
            model.Error = "An error occurred. Please try again later.";
            return View("Index", model);
        }
    }
}