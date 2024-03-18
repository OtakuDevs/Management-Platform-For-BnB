using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Skeppsgarden.Common.Constants.GeneralApplicationConstants;

namespace Skeppsgarden.Web.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = AdministratorRoleName)]
[Route("easydata")]
public class EasyAdminController : Controller
{
    private readonly ILogger<EasyAdminController> _logger;

    public EasyAdminController(ILogger<EasyAdminController> logger)
    {
        _logger = logger;
    }

   [Route("{**entity}")]
    public IActionResult Index(string entity)
    {
        if (string.IsNullOrEmpty(entity))
        {
            _logger.LogInformation("Index page");
        }
        else
        {
            _logger.LogInformation($"{entity} page");
        }

        return View("Index");
    }
}