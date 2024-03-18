using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EasyData.EntityFrameworkCore;

namespace Skeppsgarden.Data.Models;

[MetaEntity(false)]
public class HistoricalReservation
{
    public HistoricalReservation()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; set; }

    public int SequenceNumber { get; set; }

    [Required]
    [ForeignKey(nameof(Customer))]
    public Guid CustomerId { get; set; }

    [Required] public Customer Customer { get; set; }

    [Required] 
    [ForeignKey(nameof(Room))] 
    public Guid RoomId { get; set; }

    [Required] public Room Room { get; set; }

    public int NumberOfGuests { get; set; }

    public int NumberOfNights { get; set; }

    public int TotalPrice { get; set; }

    public DateTime CheckIn { get; set; }

    public DateTime CheckOut { get; set; }

    //Arrival time
    public TimeSpan? CheckInTime { get; set; }

    public string? SpecialRequirements { get; set; }

    public string? NotesToCustomer { get; set; }
}