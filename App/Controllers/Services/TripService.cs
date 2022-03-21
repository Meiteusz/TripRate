using Controllers.Services.Interfaces;
using Models.Queries.Interfaces;

namespace Controllers.Services
{
    public class TripService : ITripService
    {
        private readonly ITripQuery _tripQuery;

        public TripService(ITripQuery tripQuery)
        {
            this._tripQuery = tripQuery;
        }
    }
}
