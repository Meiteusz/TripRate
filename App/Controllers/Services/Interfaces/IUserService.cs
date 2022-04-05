using Models;
using Models.DTO_s.Responses;
using System.Threading.Tasks;

namespace Controllers
{
    public interface IUserService
    {
        Task<ResponseData<User>> LoginByEmailAndPassword(string email, string password);
        Task<ResponseData<string>> CheckEmailRegisterd(string email);
        Task<Response> UpdateUserSettings(User user);
    }
}