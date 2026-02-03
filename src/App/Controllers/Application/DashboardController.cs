using LegacyGifts.App.Utility;
using Microsoft.AspNetCore.Mvc;

namespace LegacyGifts.App.Controllers.Application;

[Route("Application/[controller]/[action]")]
public class DashboardController : BaseController
{
    private const string IndexView = "~/Views/Application/Dashboard/Index.cshtml";
    private const string HeaderView = "~/Views/Application/Dashboard/Header.cshtml";
    private const string SidebarView = "~/Views/Application/Dashboard/Sidebar.cshtml";
    private const string OverviewView = "~/Views/Application/Dashboard/Overview.cshtml";

    [HttpGet]
    [Route("/")]
    [Route("~/Application/Dashboard")]
    public IActionResult Index()
    {
        ViewData["Title"] = "Dashboard — Legacy Gifts";
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
