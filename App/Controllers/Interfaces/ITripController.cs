using Models;
using Models.DTO_s.Entities;
using Models.DTO_s.Responses;

namespace Controllers.Interfaces
{
    public interface ITripController
    {
        Response RegisterTrip(Trip trip);
        ResponseQuery<Trip> GetFullQuery();
    }
}
