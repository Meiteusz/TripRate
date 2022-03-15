using Microsoft.AspNetCore.Mvc;

namespace TripRate.Controllers
{
    public class TripRegister : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
