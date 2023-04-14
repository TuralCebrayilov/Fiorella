using Microsoft.AspNetCore.Mvc;

namespace Fiorella.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
