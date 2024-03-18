using Skeppsgarden.Web.ViewModels.Activity;

namespace Skeppsgarden.Services.Data.Interfaces;

public interface IActivityService
{
    Task<ActivityCollectionViewModel> GetAllActivitiesAsync();
}