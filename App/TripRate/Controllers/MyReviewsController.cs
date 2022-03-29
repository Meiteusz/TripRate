using Controllers;
using Controllers.Administration;
using Controllers.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Index()
        {
            ViewBag.QueryUserReviewTrips = _tripController.GetUserTripReviews(TripRateAdministration.GetCurrentUserLogged().Id).Query;
            return View();
        }
    }
}
