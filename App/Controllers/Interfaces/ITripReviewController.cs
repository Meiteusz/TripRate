using Models;
using Models.Entities;
using Models.DTO_s.Responses;
using System.Threading.Tasks;

namespace Controllers.Interfaces
{
    public interface ITripReviewController
    {
        Task<Response> RegisterTrip(ReviewTrip trip);
        Task<ResponseQuery<ReviewTrip>> GetFullQuery();
        Task<ResponseQuery<ReviewTrip>> GetUserTripReviews(int userId);
        Task<ResponseQuery<ReviewTrip>> GetTripReviewsWithLocalization(string localization);
    }
}
