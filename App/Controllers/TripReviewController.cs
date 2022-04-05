using Controllers.Interfaces;
using Controllers.Services.Interfaces;
using Models;
using Models.Entities;
using Models.DTO_s.Responses;
using Models.Queries.Interfaces;
using System.Threading.Tasks;
using Models.BaseClasses;

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

        public async Task<Response> RegisterTrip(ReviewTrip trip)
        {
            trip.UserId = Administration.TripRateAdministration.GetCurrentUserLogged().Id;
            return await trip.SaveAsync();
        }

        public async Task<ResponseQuery<ReviewTrip>> GetFullQuery()
        {
            return await _tripQuery.GetAllAsync();
        }

        public async Task<ResponseQuery<ReviewTrip>> GetUserTripReviews(int userId)
        {
            if (userId.IsValidId())
            {
                return await _tripQuery.GetUserTripReviews(userId);
            }
            return new ResponseQuery<ReviewTrip>() { Message = "User not finded" };
        }
    }
}
