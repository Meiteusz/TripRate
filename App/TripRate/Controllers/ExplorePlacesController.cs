using Controllers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Web;

namespace TripRate.Controllers
{
    public class ExplorePlacesController : Controller
    {
        private readonly ITripReviewController _tripReviewController;

        public ExplorePlacesController(ITripReviewController tripReviewController)
        {
            this._tripReviewController = tripReviewController;
        }

        public async Task<IActionResult> Index(string localization)
        {
            var tripReviews = await _tripReviewController.GetTripReviewsWithLocalization(localization);
            ViewBag.TripReviewsSearchedResponse = tripReviews;

            return View();
        }

        public async Task<IActionResult> OpenHotels(string localization)
        {
            return RedirectToAction("Index", "Hotel", new { localization = localization });
        }
    }
}
