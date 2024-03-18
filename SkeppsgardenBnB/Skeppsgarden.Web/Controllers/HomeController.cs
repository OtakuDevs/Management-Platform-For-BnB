using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Skeppsgarden.Data.Models;
using Skeppsgarden.Services.Data.Interfaces;
using Skeppsgarden.Web.ViewModels;

namespace Skeppsgarden.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    
    private readonly IHomeService _homeService;

    public HomeController(ILogger<HomeController> logger, IHomeService service)
    {
        _logger = logger;
        _homeService = service;
    }

    public IActionResult Index()
    {
        var viewModel = _homeService.GetHomeViewModelAsync().Result;
        return View(viewModel);
    }
    
    public IActionResult About()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}