using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LegacyGifts.Admin.Controllers.Ops;

[Route("Ops/[controller]/[action]")]
[Authorize(Policy = "RequireOps")]
public class VerificationsController : BaseController
{
    private const string ListView = "~/Views/Ops/Verifications/List.cshtml";
    private const string DetailView = "~/Views/Ops/Verifications/Detail.cshtml";

    [HttpGet]
    public IActionResult List()
    {
        return View(ListView);
    }

    [HttpGet]
    public IActionResult Detail(string id)
    {
        ViewData["VerificationId"] = id;
        return View(DetailView);
    }
}
