using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.Admin.Controllers
{
    public class HomeAnimationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
