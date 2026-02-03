using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Flowers.Web.Controllers.Application;

[Route("Application/[controller]/[action]")]
[Authorize(Policy = "RequireBenefactor")]
public class GiftsController : BaseController
{
    private const string ListView = "~/Views/Application/Gifts/List.cshtml";
    private const string DetailView = "~/Views/Application/Gifts/Detail.cshtml";
    private const string FormView = "~/Views/Application/Gifts/Form.cshtml";
    private const string CatalogView = "~/Views/Application/Gifts/Catalog.cshtml";

    [HttpGet]
    public IActionResult List()
    {
        return View(ListView);
    }

    [HttpGet]
    public IActionResult Detail(string id)
    {
        ViewData["GiftId"] = id;
        return View(DetailView);
    }

    [HttpGet]
    public IActionResult Form(string? id = null)
    {
        ViewData["GiftId"] = id;
        ViewData["IsNew"] = string.IsNullOrEmpty(id);
        return View(FormView);
    }

    [HttpGet]
    public IActionResult Catalog()
    {
        return View(CatalogView);
    }
}
