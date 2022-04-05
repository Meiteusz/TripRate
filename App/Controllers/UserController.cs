using Controllers.Administration;
using Models;
using Models.DTO_s.CustomExceptions;
using Models.DTO_s.Responses;
using Models.Enums;
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

        public async Task<Response> RegisterUser(User user)
        {
            user.UserType = UserTypes.DEFAULT;
            return await user.SaveAsync();
        }

        public async Task<Response> ResetPassword(string email)
        {
            var response = await _userService.CheckEmailRegisterd(email);

            if (response.Success)
            {
                // send email code to resed password
                return new Response();
            }

            return new ResponseException() { Exception = new FailedToFindEmailException(email) };
        }

        public async Task<Response> UpdateUserSettings(User user)
        {
            var actualUser = TripRateAdministration.GetCurrentUserLogged();
            actualUser.Name = user.Name;
            actualUser.Email = user.Email;
            actualUser.Password = user.Password;
            return await _userService.UpdateUserSettings(actualUser);
        }
    }
}
