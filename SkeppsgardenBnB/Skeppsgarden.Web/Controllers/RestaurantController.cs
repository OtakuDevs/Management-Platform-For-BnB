using Microsoft.AspNetCore.Mvc;
using Skeppsgarden.Services.Data.Interfaces;

namespace Skeppsgarden.Web.Controllers;

public class RestaurantController : Controller
{
    private readonly IRestaurantService _restaurantService;
    
    public RestaurantController(IRestaurantService restaurantService)
    {
        _restaurantService = restaurantService;
    }
    
    public async Task<IActionResult> Index()
    {
        var restaurantViewModels = await _restaurantService.GetRestaurantViewModelAsync();
        return View(restaurantViewModels);
    }
}