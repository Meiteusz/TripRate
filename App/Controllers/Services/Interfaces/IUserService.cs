using Models;
using Models.DTO_s.Responses;

namespace Controllers
{
    public interface IUserService
    {
        ResponseData<User> LoginByEmailAndPassword(string email, string password);
        ResponseData<string> CheckEmailRegisterd(string email);
    }
}