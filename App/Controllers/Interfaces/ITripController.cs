using Models;
using Models.DTO_s.Entities;

namespace Controllers.Interfaces
{
    public interface ITripController
    {
        Response RegisterTrip(Trip trip);
    }
}
