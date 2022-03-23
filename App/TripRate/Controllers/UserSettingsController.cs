using Microsoft.AspNetCore.Mvc;

namespace TripRate.Controllers
{
    public class UserSettingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
