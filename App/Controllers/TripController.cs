using Controllers.Interfaces;
using Controllers.Services.Interfaces;
using Models;
using Models.DTO_s.Entities;

namespace Controllers
{
    public class TripController : ITripController
    {
        private readonly ITripService _tripService;

        public TripController(ITripService tripService)
        {
            this._tripService = tripService;
        }

        public Response RegisterTrip(Trip trip)
        {
            return trip.Save();
        }
    }
}
