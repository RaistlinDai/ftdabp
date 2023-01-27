using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace ftdabp;

public class HomeController : AbpController
{
    public IActionResult Index()
    {
        return Content("Hello ftd");
    }
}