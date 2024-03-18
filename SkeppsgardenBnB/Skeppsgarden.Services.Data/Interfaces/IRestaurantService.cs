using Skeppsgarden.Web.ViewModels.Restaurant;

namespace Skeppsgarden.Services.Data.Interfaces;

public interface IRestaurantService 
{
    Task<ICollection<RestaurantViewModel>> GetRestaurantViewModelAsync();
}