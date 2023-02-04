using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class WeddingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
