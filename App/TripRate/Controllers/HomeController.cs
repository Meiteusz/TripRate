using Controllers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TripRate.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITripReviewController _tripReviewController;

        public HomeController(ITripReviewController tripReviewController)
        {
            this._tripReviewController = tripReviewController;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Search(string localization)
        {
            var tripReviews = await _tripReviewController.GetTripReviewsWithLocalization(localization);

            return RedirectToAction("Index", "ExplorePlaces", new { localization = localization});
        }
    }
}
