using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LegacyGifts.App.Controllers.Application;

[Route("Application/[controller]/[action]")]
[Authorize(Policy = "RequireBenefactor")]
public class BeneficiariesController : BaseController
{
    private const string ListView = "~/Views/Application/Beneficiaries/List.cshtml";
    private const string DetailView = "~/Views/Application/Beneficiaries/Detail.cshtml";
    private const string FormView = "~/Views/Application/Beneficiaries/Form.cshtml";

    [HttpGet]
    public IActionResult List()
    {
        return View(ListView);
    }

    [HttpGet]
    public IActionResult Detail(string id)
    {
        ViewData["BeneficiaryId"] = id;
        return View(DetailView);
    }

    [HttpGet]
    public IActionResult Form(string? id = null)
    {
        ViewData["BeneficiaryId"] = id;
        ViewData["IsNew"] = string.IsNullOrEmpty(id);
        return View(FormView);
    }
}
