using LegacyGifts.Admin.Utility;
using Microsoft.AspNetCore.Mvc;

namespace LegacyGifts.Admin.Controllers.Ops;

[Route("Ops/[controller]/[action]")]
public class DashboardController : BaseController
{
    private const string IndexView = "~/Views/Ops/Dashboard/Index.cshtml";
    private const string HeaderView = "~/Views/Ops/Dashboard/Header.cshtml";
    private const string SidebarView = "~/Views/Ops/Dashboard/Sidebar.cshtml";
    private const string OverviewView = "~/Views/Ops/Dashboard/Overview.cshtml";

    [HttpGet]
    [Route("/")]
    [Route("~/Ops/Dashboard")]
    public IActionResult Index()
    {
        ViewData["Title"] = "Admin — Legacy Gifts";
        ViewData["AssemblyVersion"] = Program.AssemblyVersion;
        ViewData["AssemblyVersionWithTimestamp"] = AssemblyVersionWithTimestamp;
        ViewData["ImportMap"] = ImportMapFactory.GetImportMap(
            HttpContext.RequestServices.GetRequiredService<IWebHostEnvironment>().WebRootPath,
            AssemblyVersionWithTimestamp);

        return View(IndexView);
    }

    [HttpGet]
    public IActionResult Header()
    {
        return View(HeaderView);
    }

    [HttpGet]
    public IActionResult Sidebar()
    {
        return View(SidebarView);
    }

    [HttpGet]
    public IActionResult Overview()
    {
        return View(OverviewView);
    }
}
