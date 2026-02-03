using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Flowers.Web.Admin.Controllers.Ops;

[Route("Ops/[controller]/[action]")]
[Authorize(Policy = "RequireAdmin")]
public class AuditController : BaseController
{
    private const string LogsView = "~/Views/Ops/Audit/Logs.cshtml";
    private const string ReportsView = "~/Views/Ops/Audit/Reports.cshtml";

    [HttpGet]
    public IActionResult Logs()
    {
        return View(LogsView);
    }

    [HttpGet]
    public IActionResult Reports()
    {
        return View(ReportsView);
    }
}
