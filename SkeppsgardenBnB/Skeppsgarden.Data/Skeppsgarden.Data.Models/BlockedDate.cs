using System.ComponentModel.DataAnnotations.Schema;
using EasyData.EntityFrameworkCore;

namespace Skeppsgarden.Data.Models;

[MetaEntity(false)]
public class BlockedDate
{
    public BlockedDate()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string? Reason { get; set; }

    [ForeignKey(nameof(Room))] 
    public Guid RoomId { get; set; }
    public Room Room { get; set; }
}