using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;
using Skeppsgarden.Data.Models;

namespace Skeppsgarden.Web.Areas.Admin.ViewModels.FormModels;

public class ReservationFormModel
{
    public ReservationFormModel()
    {
       SequenceNumber = 0;
    }

    [Required] 
    public Guid Id { get; set; }

    [Required] 
    public int SequenceNumber { get; set; }
    
    [Required]
    public Guid CustomerId { get; set; }
    
    [Required]
    public Guid RoomId { get; set; }
    
    [Required]
    public int NumberOfGuests { get; set; }
    
    [Required]
    public int NumberOfNights { get; set; }
    
    [Required]
    public int TotalPrice { get; set; }
    
    [Required]
    public DateTime CheckIn { get; set; }
    
    [Required]
    public DateTime CheckOut { get; set; }
    
    //Arrival time
    [DataType(DataType.Time)]
    public TimeSpan? CheckInTime { get; set; }
    
    public string? SpecialRequirements { get; set; }
    
    public string? NotesToCustomer { get; set; }
    
    public string? Error { get; set; }
    
    public bool CreateNewCustomer { get; set; }
    
    public string? NewCustomerFirstName { get; set; }
    
    public string? NewCustomerLastName { get; set; }
    
    public string? NewCustomerEmail { get; set; }
    
    public string? NewCustomerPhoneNumber { get; set; }
    
    public IEnumerable<SelectListItem> Customers { get; set; }
    
    public IEnumerable<SelectListItem> Rooms { get; set; }
}