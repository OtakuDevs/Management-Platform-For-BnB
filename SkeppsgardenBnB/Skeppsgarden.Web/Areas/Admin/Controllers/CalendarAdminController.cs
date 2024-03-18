using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Skeppsgarden.Web.Areas.Admin.Services.Interfaces;
using static Skeppsgarden.Common.Constants.GeneralApplicationConstants;

namespace Skeppsgarden.Web.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = AdministratorRoleName)]
[AutoValidateAntiforgeryToken]
public class CalendarAdminController : Controller
{
    private readonly ICalendarAdminService _calendarAdminService;
    private readonly ILogger<CalendarAdminController> _logger;

    public CalendarAdminController(ICalendarAdminService adminActionsService, ILogger<CalendarAdminController> logger)
    {
        _calendarAdminService = adminActionsService;
        _logger = logger;
    }
    
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpGet]
    public async Task<JsonResult> Calendar()
    {
        JsonResult result;
        
        try
        {
            var bookings = await _calendarAdminService.GetCurrentBookings();
            result = Json(bookings);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while getting bookings");
            result = Json(new { error = e.Message });
        }

        return result;
    }
}