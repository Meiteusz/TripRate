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

            if (!tripReviews.Success)
            {
                // Show the exception message on a h4
            }
            else
            {
                // Get the query values to the table on cshtml
            }

            return RedirectToAction("Index", "ExplorePlaces");
        }
    }
}
