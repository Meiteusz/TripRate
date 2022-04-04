using Controllers.Administration;
using Models;
using Models.DTO_s.CustomExceptions;
using Models.DTO_s.Responses;
using System.Threading.Tasks;

namespace Controllers
{
    public class UserController : IUserController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        public async Task<ResponseData<User>> LoginByEmailAndPassword(string email, string password)
        {
            return await _userService.LoginByEmailAndPassword(email, password);
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

        public Response UpdateUserSettings(User user)
        {
            var actualUser = TripRateAdministration.GetCurrentUserLogged();
            actualUser.Name = user.Name;
            actualUser.Email = user.Email;
            actualUser.Password = user.Password;
            return _userService.UpdateUserSettings(actualUser);
        }
    }
}
