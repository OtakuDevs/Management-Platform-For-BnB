namespace Skeppsgarden.Web.ViewModels.Restaurant;

public class RestaurantViewModel
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Website { get; set; } = null!;

    public string Description { get; set; } = null!;
    
    public TimeSpan OpenWorkingHours { get; set; }
    
    public TimeSpan CloseWorkingHours { get; set; }
    
    public string? Image { get; set; }
    
    public ICollection<MenuItemsViewModel> MenuItems { get; set; } = new HashSet<MenuItemsViewModel>();
}