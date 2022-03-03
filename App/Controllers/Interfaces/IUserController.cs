using Models;

namespace Controllers
{
    public interface IUserController
    {
        Response RegisterUser(User user);
    }
}