using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.Admin.Controllers
{
    public class HomeSliderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
