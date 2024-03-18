using EasyData.EntityFrameworkCore;

namespace Skeppsgarden.Data.Models;

using System.ComponentModel.DataAnnotations;
using static Common.Constants.DatabaseEntitiesValidationConstants.HyperlinkConstants;

public class Hyperlink
{
    [MetaEntityAttr(ShowOnView = false)]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(TextMaxLength)]
    [Display(Name = "Name of Website")]
    public string Text { get; set; } = null!;
    
    [Required]
    [MaxLength(UrlMaxLength)]
    public string Url { get; set; } = null!;
}