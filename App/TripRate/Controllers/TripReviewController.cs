using AutoMapper;
using Controllers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using System.Threading.Tasks;
using TripRate.Models;

namespace TripRate.Controllers
{
    [Route("Trips")]
    public class TripReviewController : Controller
    {
        private readonly ITripReviewController _tripReviewController;
        private readonly IMapper _mapper;

        public TripReviewController(ITripReviewController tripReviewController, IMapper mapper)
        {
            this._tripReviewController = tripReviewController;
            this._mapper = mapper;
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.QueryReviewTrips = _tripReviewController.GetFullQuery().Query;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> RegisterTripReview()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmRegisterReviewTrip(ModelTrip modelTrip)
        {
            var trip = _mapper.Map<ReviewTrip>(modelTrip);
            var response = _tripReviewController.RegisterTrip(trip);

            if (response.Success)
            {
                return RedirectToAction("Index", "Trips");
            }
            else
            {
                return RedirectToAction("Error", "ErrorBag");
            }
        }

        public async Task<IActionResult> ConfirmAndNewReviewTrip()
        {
            return View();
        }

        public async Task<IActionResult> Cancel()
        {
            return View();
        }
    }
}
