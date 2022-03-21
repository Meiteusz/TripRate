using Controllers.Interfaces;
using Controllers.Services.Interfaces;
using Models;
using Models.DTO_s.Entities;
using Models.DTO_s.Responses;
using Models.Queries.Interfaces;

namespace Controllers
{
    public class TripController : ITripController
    {
        private readonly ITripService _tripService;
        private readonly ITripQuery _tripQuery;

        public TripController(ITripService tripService, ITripQuery tripQuery)
        {
            this._tripService = tripService;
            this._tripQuery = tripQuery;
        }

        public Response RegisterTrip(Trip trip)
        {
            return trip.Save();
        }

        public ResponseQuery<Trip> GetFullQuery()
        {
            return _tripQuery.GetAll();
        }
    }
}
