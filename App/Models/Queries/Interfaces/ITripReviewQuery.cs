using Models.Entities;
using Models.DTO_s.Responses;

namespace Models.Queries.Interfaces
{
    public interface ITripReviewQuery
    {
        ResponseQuery<ReviewTrip> GetAll();
        ResponseQuery<ReviewTrip> GetUserTripReviews(int userId);
    }
}
