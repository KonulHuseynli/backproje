using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class HighJewellerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
