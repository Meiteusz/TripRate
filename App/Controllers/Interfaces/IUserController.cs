using Models;
using Models.DTO_s.Responses;
using System.Threading.Tasks;

namespace Controllers
{
    public interface IUserController
    {
        Task<ResponseData<User>> LoginByEmailAndPassword(string email, string password);
        Task<Response> RegisterUser(User user);
        Task<Response> ResetPassword(string email);
        Task<Response> UpdateUserSettings(User user);
    }
}