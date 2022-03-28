using Models.Entities;
using Models.DTO_s.Responses;
using Models.Queries.Interfaces;
using System.Linq;

namespace Models.Queries
{
    public class TripQuery : ITripQuery
    {
        public ResponseQuery<ReviewTrip> GetAll()
        {
            using (var context = new TripRateContext())
            {
                var tripsList = context.ReviewTrips.ToList();

                if (tripsList.Count > 0)
                {
                    return new ResponseQuery<ReviewTrip>()
                    {
                        Success = true,
                        Query = tripsList
                    };
                }
                return new ResponseQuery<ReviewTrip>();
            }
        }
    }
}
