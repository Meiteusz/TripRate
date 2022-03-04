using Models;
using Models.DTO_s.Responses;

namespace Controllers
{
    public class UserController : IUserController
    {
        private readonly IUserService UserService;

        public UserController(IUserService userService)
        {
            this.UserService = userService;
        }

        public User CreateInstance() => User.CreateInstance();

        public ResponseData<User> LoginByEmailAndPassword(string email, string password)
        {
            return UserService.LoginByEmailAndPassword(email, password);
        }

        public Response RegisterUser(User user)
        {
            return user.Save();
        }
    }
}
