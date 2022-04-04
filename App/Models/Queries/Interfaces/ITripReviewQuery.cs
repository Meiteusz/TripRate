using Models.Entities;
using Models.DTO_s.Responses;
using System.Threading.Tasks;

namespace Models.Queries.Interfaces
{
    public interface ITripReviewQuery
    {
        ResponseQuery<ReviewTrip> GetAll();
        Task<ResponseQuery<ReviewTrip>> GetUserTripReviews(int userId);
    }
}
