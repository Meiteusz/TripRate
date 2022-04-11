using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TripRate.Models;

namespace TripRate.Controllers
{
    public class HotelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> HotelRegister()
        {
            return View();
        }
    }
}
