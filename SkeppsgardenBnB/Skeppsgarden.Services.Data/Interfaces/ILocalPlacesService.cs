using Skeppsgarden.Web.ViewModels.LocalPlace;

namespace Skeppsgarden.Services.Data.Interfaces;

public interface ILocalPlacesService
{
    Task<LocalPlacesCollectionViewModel> GetAllLocalPlacesAsync();
}