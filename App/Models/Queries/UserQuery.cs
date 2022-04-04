using Microsoft.EntityFrameworkCore;
using Models.Queries.Interfaces;
using System.Threading.Tasks;

namespace Models.Queries
{
    public class UserQuery : IUserQuery
    {
        public async Task<User> GetUserByEmail(string email)
        {
            using (var context = new TripRateContext())
            {
                return await context.Users.SingleOrDefaultAsync(x => x.Email == email);
            }
        }
    }
}
