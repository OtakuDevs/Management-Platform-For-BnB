using Microsoft.AspNetCore.Mvc;
using Skeppsgarden.Services.Data.Interfaces;

namespace Skeppsgarden.Web.Controllers;

public class LocalPlacesController : Controller
{
    private readonly ILocalPlacesService _localPlacesService;
    
    public LocalPlacesController(ILocalPlacesService localPlacesService)
    {
        _localPlacesService = localPlacesService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllLocalPlaces()
    {
        var model = await _localPlacesService.GetAllLocalPlacesAsync();
        return View(model);
    }
}