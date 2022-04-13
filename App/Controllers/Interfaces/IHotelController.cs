using Models;
using Models.Entities;
using System.Threading.Tasks;

namespace Controllers.Interfaces
{
    public interface IHotelController
    {
        Task<Response> RegisterHotel(Hotel hotel);
    }
}
