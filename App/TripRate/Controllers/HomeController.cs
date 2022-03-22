using Microsoft.AspNetCore.Mvc;

namespace TripRate.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            TempData["ExistsUserLogged"] = false;
            return View();
        }
    }
}
