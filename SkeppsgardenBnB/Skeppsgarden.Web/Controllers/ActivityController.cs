using Microsoft.AspNetCore.Mvc;
using Skeppsgarden.Services.Data.Interfaces;

namespace Skeppsgarden.Web.Controllers;

public class ActivityController : Controller
{
    private readonly IActivityService _activityService;

    public ActivityController(IActivityService activityService)
    {
        _activityService = activityService;
    }

    [HttpGet]
    public async Task<IActionResult> ListAllActivities()
    {
        var model = await _activityService.GetAllActivitiesAsync();
        return View(model);
    }
}