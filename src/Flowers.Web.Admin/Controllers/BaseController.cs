using Microsoft.AspNetCore.Mvc;

namespace Flowers.Web.Admin.Controllers;

public class BaseController : Controller
{
    protected string AssemblyVersionWithTimestamp =>
        Program.AssemblyVersion + "." + GetTimestamp();

    private static string GetTimestamp()
    {
#if DEBUG
        return DateTime.Now.Ticks.ToString();
#else
        return Program.AssemblyVersion.Revision.ToString();
#endif
    }
}
