using Models;
using Models.DTO_s.CustomExceptions;
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

        public Response ResetPassword(string email)
        {
            var response = UserService.CheckEmailRegisterd(email);

            if (response.Success)
            {
                // send email code to resed password
                return new Response();
            }

            return new ResponseException() { Exception = new FailedToFindEmailException(email) };
        }
    }
}
