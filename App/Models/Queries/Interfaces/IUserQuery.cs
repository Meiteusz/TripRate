using System.Threading.Tasks;

namespace Models.Queries.Interfaces
{
    public interface IUserQuery
    {
        Task<User> GetUserByEmail(string email);
    }
}
