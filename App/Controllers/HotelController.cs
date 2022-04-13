using Controllers.Interfaces;
using Models;
using Models.Entities;
using Models.Queries.Interfaces;
using System.Threading.Tasks;

namespace Controllers
{
    public class HotelController : IHotelController
    {
        private readonly IHotelQuery _hotelQuery;

        public HotelController(IHotelQuery hotelQuery)
        {
            this._hotelQuery = hotelQuery;
        }

        public async Task<Response> RegisterHotel(Hotel hotel)
        {
            return await hotel.SaveAsync();
        }
    }
}
