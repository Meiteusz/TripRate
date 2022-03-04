using Models;
using Models.DTO_s.Responses;

namespace Controllers
{
    public interface IUserController
    {
        ResponseData<User> LoginByEmailAndPassword(string email, string password);
        Response RegisterUser(User user);
    }
}