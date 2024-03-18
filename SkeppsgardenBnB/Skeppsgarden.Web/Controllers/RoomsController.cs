using FluentEmail.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Skeppsgarden.Data;
using Skeppsgarden.Web.ViewModels.Rooms;

namespace Skeppsgarden.Web.Controllers;

public class RoomsController : Controller
{
    private readonly ApplicationDbContext _data;

    public RoomsController(ApplicationDbContext data)
    {
        _data = data;
    }

    public async Task<IActionResult> ListAllRooms()
    {
        var today = DateTime.Now;
        var rooms = await _data.Rooms
            .Include(v => v.ViewType)
            .Include(r => r.RoomType)
            .Include(b => b.BedType)
            .Include(ru => ru.RoomsUtilityTypes)
            .Select(r => new ListSingleRoomViewModel()
            {
                Id = r.Id,
                Image = r.Images.Split(", ", StringSplitOptions.RemoveEmptyEntries),
                RoomNumber = r.RoomNumber,
                Level = "First floor",
                View = r.ViewType.Name.Split("View", StringSplitOptions.RemoveEmptyEntries).First() + " View",
                RoomType = r.RoomType.Type,
                Areas = r.RoomsUtilityTypes.Any()
                    ? string.Join(" • ", r.RoomsUtilityTypes.Select(rut => rut.UtilityType.Name))
                    : null,
                Capacity = r.Capacity,
                BedTypes = r.BedType.Name,
                Rate = r.Rate,
                IsAvailable = !r.BlockedDates.Any(b => b.StartDate <= today && today <= b.EndDate),
            })
            .ToListAsync();
        for (int i = 0; i < rooms.Count; i++)
        {
            rooms[i].Image = rooms[i].Image.Select(i => i + ".jpg").ToArray();
        }

        rooms = rooms.OrderBy(r => r.RoomNumber).ToList();
        var model = new ListRoomsViewModel()
        {
            Rooms = rooms,
        };
        return View(model);
    }

    [HttpGet]
    public async Task<JsonResult> GetRoomDetails(string id)
    {
        var room = await _data.Rooms
            .Include(v => v.ViewType)
            .Include(r => r.RoomType)
            .Include(b => b.BedType)
            .Include(ru => ru.RoomsUtilityTypes)
            .FirstOrDefaultAsync(r => r.Id == Guid.Parse(id));

        foreach (var type in room.RoomsUtilityTypes)
        {
            type.UtilityType = await _data.UtilityTypes.FirstOrDefaultAsync(u => u.Id == type.UtilityTypeId);
        }


        var model = new ListSingleRoomViewModel()
        {
            Id = room.Id,
            Image = room.Images.Split(", ", StringSplitOptions.RemoveEmptyEntries),
            RoomNumber = room.RoomNumber,
            Level = "First floor",
            View = room.ViewType.Name.Split("View", StringSplitOptions.RemoveEmptyEntries).First() + " View",
            RoomType = room.RoomType.Type,
            Areas = room.RoomsUtilityTypes.Any()
                ? string.Join(" • ", room.RoomsUtilityTypes.Select(rut => rut.UtilityType.Name))
                : null,
            Capacity = room.Capacity,
            BedTypes = room.BedType.Name,
            Rate = room.Rate,
        };
        return Json(model);
    }
}