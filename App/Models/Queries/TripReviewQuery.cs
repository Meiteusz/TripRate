using Models.Entities;
using Models.DTO_s.Responses;
using Models.Queries.Interfaces;
using System.Linq;

namespace Models.Queries
{
    public class TripReviewQuery : ITripReviewQuery
    {
        public ResponseQuery<ReviewTrip> GetAll()
        {
            using (var context = new TripRateContext())
            {
                var tripsList = context.ReviewTrips.ToList();

                if (tripsList.Count > 0)
                {
                    return new ResponseQuery<ReviewTrip>()
                    {
                        Success = true,
                        Query = tripsList
                    };
                }
                return new ResponseQuery<ReviewTrip>() { Message = "None trip review searched"};
            }
        }

        public ResponseQuery<ReviewTrip> GetUserTripReviews(int userId)
        {
            using (var context = new TripRateContext())
            {
                var userReviewTrips = context.ReviewTrips.Where(x => x.UserId == userId).ToList();

                if (userReviewTrips.Count > 0)
                {
                    return new ResponseQuery<ReviewTrip>()
                    {
                        Success = true,
                        Query = userReviewTrips
                    };
                }
                return new ResponseQuery<ReviewTrip>() { Message = "You dont have a trip review yet" };
            }
        }
    }
}
