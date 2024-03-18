using Microsoft.EntityFrameworkCore;
using Skeppsgarden.Data;
using Skeppsgarden.Services.Data.Interfaces;
using Skeppsgarden.Web.ViewModels.LocalPlace;

namespace Skeppsgarden.Services.Data;

public class LocalPlacesService : ILocalPlacesService
{
    private readonly ApplicationDbContext _dbContext;
    
    public LocalPlacesService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<LocalPlacesCollectionViewModel> GetAllLocalPlacesAsync()
    {
        var localPlaces = await _dbContext.LocalPlaces
            .Select(x => new LocalPlacesViewModel
            {
                Name = x.Name,
                Description = x.Description,
                Url = x.Url,
                ImageUrl = x.ImageUrl
            })
            .ToListAsync();
        var model = new LocalPlacesCollectionViewModel()
        {
            LocalPlaces = localPlaces
        };
        return model;
    }
}