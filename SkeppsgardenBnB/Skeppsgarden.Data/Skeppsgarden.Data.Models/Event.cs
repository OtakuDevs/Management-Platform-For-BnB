using EasyData.EntityFrameworkCore;

namespace Skeppsgarden.Data.Models;

using System.ComponentModel.DataAnnotations;
using static Common.Constants.DatabaseEntitiesValidationConstants.EventConstants;

[MetaEntity(false)]
public class Event
{
    public Event()
    {
        Id = Guid.NewGuid();
    }

    [MetaEntityAttr(ShowOnView = false)] 
    public Guid Id { get; set; }

    [Required] [MaxLength(TitleMaxLength)] 
    public string Title { get; set; } = null!;

    [DisplayFormat(DataFormatString = DateTimeFormat)]
    public DateTime Start { get; set; }

    [DisplayFormat(DataFormatString = DateTimeFormat)]
    public DateTime End { get; set; }

    [Required]
    [MaxLength(DescriptionMaxLength)]
    public string Description { get; set; } = null!;

    [Required]
    [MaxLength(LocationMaxLength)]
    public string Location { get; set; } = null!;

    [MaxLength(ImageUrlMaxLength)] public string? Image { get; set; }
}