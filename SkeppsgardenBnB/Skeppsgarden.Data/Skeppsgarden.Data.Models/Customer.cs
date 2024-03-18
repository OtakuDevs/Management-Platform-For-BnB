using System.ComponentModel.DataAnnotations.Schema;
using EasyData.EntityFrameworkCore;

namespace Skeppsgarden.Data.Models;

using System.ComponentModel.DataAnnotations;
using static Common.Constants.DatabaseEntitiesValidationConstants.CustomerConstants;

public class Customer
{
    public Customer()
    {
        Id = Guid.NewGuid();
    }
    
    [MetaEntityAttr(ShowOnView = false)]
    public Guid Id { get; set; }
    
    [Required]
    [RegularExpression(NameRegex)]
    [MaxLength(FirstNameMaxLength)]
    [Display(Name = "Name")]
    public string FirstName { get; set; }
    
    [Required]
    [RegularExpression(NameRegex)]
    [MaxLength(LastNameMaxLength)]
    [Display(Name = "Surname")]
    public string LastName { get; set; }
    
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    [RegularExpression(PhoneNumberRegex)]
    [Display(Name = "Phone")]
    public string PhoneNumber { get; set; }
}