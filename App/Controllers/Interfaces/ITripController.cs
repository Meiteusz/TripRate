using Models;
using Models.Entities;
using Models.DTO_s.Responses;

namespace Controllers.Interfaces
{
    public interface ITripController
    {
        Response RegisterTrip(ReviewTrip trip);
        ResponseQuery<ReviewTrip> GetFullQuery();
    }
}
