using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TripRate.Controllers
{
    public class ErrorBagController : Controller
    {
        public async Task<IActionResult> Error()
        {
            return View();
        }
    }
}
