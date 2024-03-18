using Microsoft.EntityFrameworkCore;
using Skeppsgarden.Data;
using Skeppsgarden.Data.Models.Enums;
using Skeppsgarden.Services.Data.Interfaces;
using Skeppsgarden.Web.ViewModels.Restaurant;

namespace Skeppsgarden.Services.Data;

public class RestaurantService : IRestaurantService
{
    private readonly ApplicationDbContext _dbContext;

    public RestaurantService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ICollection<RestaurantViewModel>> GetRestaurantViewModelAsync()
    {
        var restaurants = await _dbContext.Restaurants
            .Include(r => r.MenuItems)
            .ThenInclude(mi => mi.MenuItemType)
            .OrderBy(r => r.Id)
            .ToListAsync();

        var restaurantViewModels = new List<RestaurantViewModel>();
        foreach (var restaurant in restaurants)
        {
            var restaurantViewModel = new RestaurantViewModel
            {
                Id = restaurant.Id,
                Name = "Skeppskrogen",
                Description = restaurant.Description,
                OpenWorkingHours = TimeSpan.FromHours(11),
                CloseWorkingHours = TimeSpan.FromHours(23),
                MenuItems = restaurant.MenuItems.Select(mi => new MenuItemsViewModel
                {
                    Name = mi.Name,
                    MenuItemType = Enum.Parse<MenuItemTypeEnums>(mi.MenuItemType.Type),
                    Ingredients = mi.Ingredients,
                    Price = mi.Price
                }).ToList()
            };

            restaurantViewModels.Add(restaurantViewModel);
        }

        return restaurantViewModels;
    }
}