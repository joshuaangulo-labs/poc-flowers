using LegacyGifts.App.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LegacyGifts.App.Controllers.Beneficiary;

/// <summary>
/// Beneficiary portal — accessible only by beneficiary role
/// </summary>
[Route("Beneficiary/[controller]/[action]")]
[Authorize(Policy = "RequireBeneficiary")]
public class PortalController : BaseController
{
    private const string IndexView = "~/Views/Beneficiary/Portal/Index.cshtml";
    private const string HeaderView = "~/Views/Beneficiary/Portal/Header.cshtml";
    private const string GiftsView = "~/Views/Beneficiary/Portal/Gifts.cshtml";
    private const string HistoryView = "~/Views/Beneficiary/Portal/History.cshtml";
    private const string PreferencesView = "~/Views/Beneficiary/Portal/Preferences.cshtml";

    [HttpGet]
    [Route("~/Beneficiary")]
    public IActionResult Index()
    {
        ViewData["Title"] = "Your Gifts — Legacy Gifts";
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
    public IActionResult Gifts()
    {
        return View(GiftsView);
    }

    [HttpGet]
    public IActionResult History()
    {
        return View(HistoryView);
    }

    [HttpGet]
    public IActionResult Preferences()
    {
        return View(PreferencesView);
    }
}
