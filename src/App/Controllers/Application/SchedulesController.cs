using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LegacyGifts.App.Controllers.Application;

[Route("Application/[controller]/[action]")]
[Authorize(Policy = "RequireBenefactor")]
public class SchedulesController : BaseController
{
    private const string ListView = "~/Views/Application/Schedules/List.cshtml";
    private const string DetailView = "~/Views/Application/Schedules/Detail.cshtml";
    private const string FormView = "~/Views/Application/Schedules/Form.cshtml";

    [HttpGet]
    public IActionResult List()
    {
        return View(ListView);
    }

    [HttpGet]
    public IActionResult Detail(string id)
    {
        ViewData["ScheduleId"] = id;
        return View(DetailView);
    }

    [HttpGet]
    public IActionResult Form(string? id = null)
    {
        ViewData["ScheduleId"] = id;
        ViewData["IsNew"] = string.IsNullOrEmpty(id);
        return View(FormView);
    }
}
