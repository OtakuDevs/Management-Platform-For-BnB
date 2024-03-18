using Microsoft.AspNetCore.Mvc;
using Skeppsgarden.Data;
using Skeppsgarden.Web.ViewModels.Event;

namespace Skeppsgarden.Web.Controllers;

public class EventController : Controller
{
    private readonly ApplicationDbContext _data;
    
    public EventController(ApplicationDbContext data)
    {
        _data = data;
    }
    
    // GET
    public IActionResult Index()
    {
        var events = _data.Events.ToList();
        var now = DateTime.Now;

        var model = new EventListViewModel()
        {
            Events = events.Select(x => new EventViewModel
            {
                Id = x.Id.ToString(),
                Title = x.Title,
                Start = x.Start,
                End = x.End,
                Description = x.Description,
                Location = x.Location,
                Image = x.Image,
            })
            .OrderByDescending(e => e.Start)
                .ToList()
        };
        
        foreach (var e in model.Events)
        {
            e.IsInPast = e.End < now;
        }
        
        return View(model);
    }
}