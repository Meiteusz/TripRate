using AutoMapper;
using Controllers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.DTO_s.Entities;
using System.Threading.Tasks;
using TripRate.Models;

namespace TripRate.Controllers
{
    [Route("Trips")]
    public class TripsController : Controller
    {
        private readonly ITripController _tripController;
        private readonly IMapper _mapper;

        public TripsController(ITripController tripController, IMapper mapper)
        {
            this._tripController = tripController;
            this._mapper = mapper;
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.QueryTrips = _tripController.GetFullQuery().Query;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> RegisterTrip()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmRegisterTrip(ModelTrip modelTrip)
        {
            var trip = _mapper.Map<Trip>(modelTrip);
            var response = _tripController.RegisterTrip(trip);

            if (response.Success)
            {
                return View("Index");
            }
            else
            {
                return RedirectToAction("Error", "ErrorBag");
            }
        }

        public async Task<IActionResult> ConfirmAndNewTrip()
        {
            return View();
        }

        public async Task<IActionResult> Cancel()
        {
            return View();
        }
    }
}
