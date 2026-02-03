using Microsoft.AspNetCore.Mvc;

namespace Flowers.Web.Admin.Controllers.Ops;

[Route("Ops/[controller]/[action]")]
public class UsersController : BaseController
{
    private const string ListView = "~/Views/Ops/Users/List.cshtml";
    private const string DetailView = "~/Views/Ops/Users/Detail.cshtml";

    [HttpGet]
    public IActionResult List()
    {
        return View(ListView);
    }

    [HttpGet]
    public IActionResult Detail(string id)
    {
        ViewData["UserId"] = id;
        return View(DetailView);
    }
}
