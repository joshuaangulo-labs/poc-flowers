using Microsoft.AspNetCore.Mvc;

namespace LegacyGifts.App.Controllers.Application;

[Route("Application/[controller]/[action]")]
public class SettingsController : BaseController
{
    private const string IndexView = "~/Views/Application/Settings/Index.cshtml";
    private const string ProfileView = "~/Views/Application/Settings/Profile.cshtml";
    private const string FundingView = "~/Views/Application/Settings/Funding.cshtml";

    [HttpGet]
    public IActionResult Index()
    {
        return View(IndexView);
    }

    [HttpGet]
    public IActionResult Profile()
    {
        return View(ProfileView);
    }

    [HttpGet]
    public IActionResult Funding()
    {
        return View(FundingView);
    }
}
