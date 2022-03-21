using Models.DTO_s.Entities;
using Models.DTO_s.Responses;
using Models.Queries.Interfaces;
using System.Linq;

namespace Models.Queries
{
    public class TripQuery : ITripQuery
    {
        public ResponseQuery<Trip> GetAll()
        {
            using (var context = new TripRateContext())
            {
                var tripsList = context.Trips.ToList();

                if (tripsList.Count > 0)
                {
                    return new ResponseQuery<Trip>()
                    {
                        Success = true,
                        Query = tripsList
                    };
                }
                return new ResponseQuery<Trip>();
            }
        }
    }
}
