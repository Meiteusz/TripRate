using Models;
using Models.DTO_s.Responses;
using Models.Entities;
using System.Threading.Tasks;

namespace Controllers.Interfaces
{
    public interface IHotelController
    {
        Task<Response> RegisterHotel(Hotel hotel);
        Task<ResponseQuery<Hotel>> GetFullQuery();
    }
}
