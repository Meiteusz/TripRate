using Models.Entities;
using Models.DTO_s.Responses;
using System.Threading.Tasks;

namespace Models.Queries.Interfaces
{
    public interface ITripReviewQuery
    {
        Task<ResponseQuery<ReviewTrip>> GetAllAsync();
        Task<ResponseQuery<ReviewTrip>> GetUserTripReviews(int userId);
    }
}
