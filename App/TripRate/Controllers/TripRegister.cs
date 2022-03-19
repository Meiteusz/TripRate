using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TripRate.Controllers
{
    public class TripRegister : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> RegisterTrip()
        {
            return RedirectToAction("Index", "Login");
        }

        public async Task<IActionResult> RegisterNewAndTrip()
        {
            return View();
        }

        public async Task<IActionResult> Cancel()
        {
            return View();
        }
    }
}
