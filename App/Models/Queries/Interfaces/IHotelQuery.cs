using Models.DTO_s.Responses;
using Models.Entities;
using System.Threading.Tasks;

namespace Models.Queries.Interfaces
{
    public interface IHotelQuery
    {
        Task<ResponseQuery<Hotel>> GetAllAsync();
    }
}
