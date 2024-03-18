namespace Skeppsgarden.Services.Data;

using Interfaces;
using Web.ViewModels.Home;


public class HomeService : IHomeService
{
    public Task<HomeViewModel> GetHomeViewModelAsync()
    {
        var galleryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "gallery");
        var images = Directory.GetFiles(galleryPath, "*.jpg").Select(Path.GetFileName).ToList();
        var viewModel = new HomeViewModel { Images = images! };
        return Task.FromResult(viewModel);
    }
}