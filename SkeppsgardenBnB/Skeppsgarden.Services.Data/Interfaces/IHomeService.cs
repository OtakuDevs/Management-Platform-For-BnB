using Skeppsgarden.Web.ViewModels.Home;

namespace Skeppsgarden.Services.Data.Interfaces;

public interface IHomeService
{
    Task<HomeViewModel> GetHomeViewModelAsync();
}