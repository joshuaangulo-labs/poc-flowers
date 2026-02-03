using Microsoft.AspNetCore.Mvc;

namespace Flowers.Web.Admin.Controllers.Ops;

[Route("Ops/[controller]/[action]")]
public class DeliveriesController : BaseController
{
    private const string ListView = "~/Views/Ops/Deliveries/List.cshtml";
    private const string DetailView = "~/Views/Ops/Deliveries/Detail.cshtml";
    private const string ExceptionsView = "~/Views/Ops/Deliveries/Exceptions.cshtml";

    [HttpGet]
    public IActionResult List()
    {
        return View(ListView);
    }

    [HttpGet]
    public IActionResult Detail(string id)
    {
        ViewData["DeliveryId"] = id;
        return View(DetailView);
    }

    [HttpGet]
    public IActionResult Exceptions()
    {
        return View(ExceptionsView);
    }
}
