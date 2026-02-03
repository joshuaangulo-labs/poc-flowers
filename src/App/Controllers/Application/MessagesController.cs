using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LegacyGifts.App.Controllers.Application;

[Route("Application/[controller]/[action]")]
[Authorize(Policy = "RequireBenefactor")]
public class MessagesController : BaseController
{
    private const string ListView = "~/Views/Application/Messages/List.cshtml";
    private const string DetailView = "~/Views/Application/Messages/Detail.cshtml";
    private const string FormView = "~/Views/Application/Messages/Form.cshtml";

    [HttpGet]
    public IActionResult List()
    {
        return View(ListView);
    }

    [HttpGet]
    public IActionResult Detail(string id)
    {
        ViewData["MessageId"] = id;
        return View(DetailView);
    }

    [HttpGet]
    public IActionResult Form(string? id = null)
    {
        ViewData["MessageId"] = id;
        ViewData["IsNew"] = string.IsNullOrEmpty(id);
        return View(FormView);
    }
}
