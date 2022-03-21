using Models.DTO_s.Entities;
using Models.DTO_s.Responses;

namespace Models.Queries.Interfaces
{
    public interface ITripQuery
    {
        ResponseQuery<Trip> GetAll();
    }
}
