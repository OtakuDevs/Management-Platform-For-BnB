using Microsoft.EntityFrameworkCore;

using Skeppsgarden.Data;
using Skeppsgarden.Services.Data.Interfaces;
using Skeppsgarden.Web.ViewModels.Activity;

namespace Skeppsgarden.Services.Data;

public class ActivityService : IActivityService
{
    private readonly ApplicationDbContext _dbContext;
    
    public ActivityService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<ActivityCollectionViewModel> GetAllActivitiesAsync()
    {
        var activities = await _dbContext.Activities
            .Select(x => new ActivityViewModel
            {
                Name = x.Name,
                Description = x.Description,
                Url = x.Url,
                ImageUrl = x.ImageUrl
            })
            .ToListAsync();
        var model = new ActivityCollectionViewModel()
        {
            Activities = activities
        };
        return model;
    }
}