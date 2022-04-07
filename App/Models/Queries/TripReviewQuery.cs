using Models.Entities;
using Models.DTO_s.Responses;
using Models.Queries.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Models.Queries
{
    public class TripReviewQuery : ITripReviewQuery
    {
        public async Task<ResponseQuery<ReviewTrip>> GetAllAsync()
        {
            using (var context = new TripRateContext())
            {
                var tripsList = await context.ReviewTrips.ToListAsync();

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

        public async Task<ResponseQuery<ReviewTrip>> GetUserTripReviews(int userId)
        {
            using (var context = new TripRateContext())
            {
                var userReviewTrips = await context.ReviewTrips
                                                   .Where(x => x.UserId == userId)
                                                   .ToListAsync();

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

        public async Task<ResponseQuery<ReviewTrip>> GetTripReviewsWithLocalization(string localization)
        {
            using (var context = new TripRateContext())
            {
                var tripReviewsLocalization = await context.ReviewTrips
                                                           .Where(x => x.Localization == localization)
                                                           .ToListAsync();

                if (tripReviewsLocalization.Count > 0)
                {
                    return new ResponseQuery<ReviewTrip>()
                    {
                        Success = true,
                        Query = tripReviewsLocalization
                    };
                }
                return new ResponseQuery<ReviewTrip>() { Message = "Don't have review to this trip yet" };
            }
        }
    }
}
