using Microsoft.AspNetCore.Mvc;

namespace Skeppsgarden.Web.Controllers;

public class ContactController : Controller
{
    private readonly IConfiguration _configuration;
    
    public ContactController(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    // GET
    public IActionResult Index()
    {
        var googleMapApi = _configuration["GoogleMapApi:ApiKey"];
        ViewData["GoogleMapApi"] = googleMapApi;
        
        return View();
    }
}