using Microsoft.AspNetCore.Mvc;

namespace TripRate.Controllers
{
    public class ExplorePlacesController : Controller
    {
        [HttpGet("{id}")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
