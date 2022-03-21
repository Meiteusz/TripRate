using AutoMapper;
using Controllers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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

        public async Task<IActionResult> RegisterTrip()
        {
            return RedirectToAction("Index","TripRegister");
        }
    }
}
