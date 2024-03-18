using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Skeppsgarden.Data;
using Skeppsgarden.Data.Models;
using Skeppsgarden.Web.ViewModels;

namespace Skeppsgarden.Web.Components;

public class RequestNotifications : ViewComponent
{
    private readonly ApplicationDbContext _data;
    
    public RequestNotifications(ApplicationDbContext data)
    {
        _data = data;
    }
    
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var requests = await _data.Requests
            .Where(r => r.IsConfirmed == false)
            .ToListAsync();
        
        var model = new RequestComponentViewModel
        {
            Count = requests.Count,
            Requests = requests.Select(r => new SingleRequestViewModel
            {
                Date =  r.CheckIn,
            })
                .OrderByDescending(d => d.Date)
                .Take(5)
                .ToList()
        };
        
        return View(model);
    }
}