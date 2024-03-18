using Skeppsgarden.Data.Models;

namespace Skeppsgarden.Data.Seeders;

public class EventsSeeder
{
    public readonly ICollection<Event> _Events;
    
    public EventsSeeder()
    {
        _Events = new List<Event>();
        _Events = GenerateEvents();
    }

    private ICollection<Event> GenerateEvents()
    {
        var list = new List<Event>()
        {
            new Event()
            {
                Id = Guid.NewGuid(),
                Title = "Stand-up Open Mic",
                Start = DateTime.UtcNow,
                End = DateTime.UtcNow,
                Description = "Enjoy an evening filled with laughter as comedians take the stage for an open mic stand-up session.",
                Location = "Main Stage Skeppsgården",
                Image = "~/images/events/comedy.jpg"
            },
            new Event()
            {
                Id = Guid.NewGuid(),
                Title = "Irish Folk Music",
                Start = DateTime.UtcNow,
                End = DateTime.UtcNow,
                Description = "Immerse yourself in the soulful tunes of Irish folk music, performed live on the Main Stage at Skeppsgården.",
                Location = "Main Stage Skeppsgården",
                Image = "~/images/events/concert.jpg"
            },
            new Event()
            {
                Id = Guid.NewGuid(),
                Title = "Boring Conference",
                Start = DateTime.UtcNow,
                End = DateTime.UtcNow,
                Description = "Unconventional and ironically entertaining, join the Boring Conference for a unique experience on the Main Stage at Skeppsgården.",
                Location = "Main Stage Skeppsgården",
                Image = "~/images/events/conference.jpg"
            },
            new Event()
            {
                Id = Guid.NewGuid(),
                Title = "Mr. and Mrs. Skeppsgården Wedding",
                Start = DateTime.UtcNow,
                End = DateTime.UtcNow,
                Description = "Witness a beautiful union at the grand Mr. and Mrs. Skeppsgården Wedding on the Main Stage, filled with love and joy.",
                Location = "Main Stage Skeppsgården",
                Image = "~/images/events/wedding.jpg"
            }
        };
        
        return list;
    }
}