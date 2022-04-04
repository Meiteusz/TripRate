using Controllers.Interfaces;
using Controllers.Services.Interfaces;
using Models;
using Models.Entities;
using Models.DTO_s.Responses;
using Models.Queries.Interfaces;
using System.Threading.Tasks;

namespace Controllers
{
    public class TripReviewController : ITripReviewController
    {
        private readonly ITripService _tripService;
        private readonly ITripReviewQuery _tripQuery;

        public TripReviewController(ITripService tripService, ITripReviewQuery tripQuery)
        {
            this._tripService = tripService;
            this._tripQuery = tripQuery;
        }

        public Response RegisterTrip(ReviewTrip trip)
        {
            trip.UserId = Administration.TripRateAdministration.GetCurrentUserLogged().Id;
            return trip.Save();
        }

        public ResponseQuery<ReviewTrip> GetFullQuery()
        {
            return _tripQuery.GetAll();
        }

        public async Task<ResponseQuery<ReviewTrip>> GetUserTripReviews(int userId)
        {
            if (userId > 0)
            {
                return await _tripQuery.GetUserTripReviews(userId);
            }
            return new ResponseQuery<ReviewTrip>() { Message = "User not finded" };
        }
    }
}
