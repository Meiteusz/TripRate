﻿using Controllers.Interfaces;
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

            var teste = HttpUtility.ParseQueryString(Request.QueryString.Value).Get("localization");

            return View();
        }

        public async Task<IActionResult> OpenHotels()
        {
            return RedirectToAction("Index", "Hotel");
        }
    }
}
