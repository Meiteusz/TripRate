using AutoMapper;
using Controllers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.DTO_s.Entities;
using System.Threading.Tasks;
using TripRate.Models;

namespace TripRate.Controllers
{
    public class TripRegister : Controller
    {
        private readonly ITripController _tripController;
        private readonly IMapper _mapper;

        public TripRegister(ITripController tripController, IMapper mapper)
        {
            this._tripController = tripController;
            this._mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterTripAsync(ModelTrip modelTrip)
        {
            var trip = _mapper.Map<Trip>(modelTrip);
            var response = _tripController.RegisterTrip(trip);
            
            if (response.Success)
            {
                return RedirectToAction("Index", "TripRegister");
            }
            else
            {
                return RedirectToAction("Error", "ErrorBag");
            }
        }

        public async Task<IActionResult> RegisterNewAndTrip()
        {
            return View();
        }

        public async Task<IActionResult> Cancel()
        {
            return View();
        }
    }
}
