using Models;
using Models.DTO_s.CustomExceptions;
using Models.DTO_s.Responses;

namespace Controllers
{
    public class UserController : IUserController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        public ResponseData<User> LoginByEmailAndPassword(string email, string password)
        {
            return _userService.LoginByEmailAndPassword(email, password);
        }

        public Response RegisterUser(User user)
        {
            return user.Save();
        }

        public Response ResetPassword(string email)
        {
            var response = _userService.CheckEmailRegisterd(email);

            if (response.Success)
            {
                // send email code to resed password
                return new Response();
            }

            return new ResponseException() { Exception = new FailedToFindEmailException(email) };
        }
    }
}
