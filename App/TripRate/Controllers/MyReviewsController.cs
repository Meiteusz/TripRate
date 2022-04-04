using Controllers;
using Controllers.Administration;
using Controllers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TripRate.Controllers
{
    [Route("UserReviewTrips")]
    public class MyReviewsController : Controller
    {
        private readonly ITripReviewController _tripController;

        public MyReviewsController(ITripReviewController tripController)
        {
            this._tripController = tripController;
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.QueryUserReviewTrips = _tripController.GetUserTripReviews(TripRateAdministration.GetCurrentUserLogged().Id).Result.Query;
            return View();
        }
    }
}
