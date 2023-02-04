using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class FineJewellerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
