using Models;
using Models.DTO_s.Responses;
using System.Threading.Tasks;

namespace Controllers
{
    public interface IUserController
    {
        Task<ResponseData<User>> LoginByEmailAndPassword(string email, string password);
        Response RegisterUser(User user);
        Response ResetPassword(string email);
        Response UpdateUserSettings(User user);
    }
}