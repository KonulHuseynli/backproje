using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.Admin.Controllers
{
    public class WeddingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
