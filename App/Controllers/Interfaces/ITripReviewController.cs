using Models;
using Models.Entities;
using Models.DTO_s.Responses;

namespace Controllers.Interfaces
{
    public interface ITripReviewController
    {
        Response RegisterTrip(ReviewTrip trip);
        ResponseQuery<ReviewTrip> GetFullQuery();
        ResponseQuery<ReviewTrip> GetUserTripReviews(int userId);
    }
}
