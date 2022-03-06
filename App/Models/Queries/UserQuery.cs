using Models.Queries.Interfaces;
using System.Linq;

namespace Models.Queries
{
    public class UserQuery : IUserQuery
    {
        public User GetUserByEmail(string email)
        {
            using (var context = new TripRateContext())
            {
                return context.Users.SingleOrDefault(x => x.Email == email);
            }
        }
    }
}
