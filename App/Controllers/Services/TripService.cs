using Controllers.Services.Interfaces;
using Models.Queries.Interfaces;

namespace Controllers.Services
{
    public class TripService : ITripService
    {
        private readonly ITripReviewQuery _tripQuery;

        public TripService(ITripReviewQuery tripQuery)
        {
            this._tripQuery = tripQuery;
        }
    }
}
