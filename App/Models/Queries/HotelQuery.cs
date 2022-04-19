using Microsoft.EntityFrameworkCore;
using Models.DTO_s.Responses;
using Models.Entities;
using Models.Queries.Interfaces;
using System.Threading.Tasks;

namespace Models.Queries
{
    public class HotelQuery : IHotelQuery
    {
        public async Task<ResponseQuery<Hotel>> GetAllAsync()
        {
            using (var context = new TripRateContext())
            {
                var hotelList = await context.Hotels.ToListAsync();

                if (hotelList.Count > 0)
                {
                    return new ResponseQuery<Hotel>()
                    {
                        Success = true,
                        Query = hotelList
                    };
                }
                return new ResponseQuery<Hotel>() { Message = "No hotels registerd yet" };
            }
        }
    }
}
