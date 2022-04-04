using Models;
using Models.Entities;
using Models.DTO_s.Responses;
using System.Threading.Tasks;

namespace Controllers.Interfaces
{
    public interface ITripReviewController
    {
        Response RegisterTrip(ReviewTrip trip);
        ResponseQuery<ReviewTrip> GetFullQuery();
        Task<ResponseQuery<ReviewTrip>> GetUserTripReviews(int userId);
    }
}
