using Controllers.Administration;
using Models;
using Models.DTO_s.Responses;
using Models.Queries.Interfaces;

namespace Controllers
{
    public class UserService : IUserService
    {
        private readonly IUserQuery _userQuery;

        public UserService(IUserQuery userQuery)
        {
            this._userQuery = userQuery;
        }

        public ResponseData<User> LoginByEmailAndPassword(string email, string password)
        {
            var user = User.GetFirstOrDefault(email, password);

            if (user.Id == null)
                return new ResponseData<User>(); //throw a Custom Exception

            TripRateAdministration.SetCurrentUserLogged(user);
            return new ResponseData<User>()
            {
                Success = true,
                Message = "Logged Succeffuly",
                Data = user
            };
        }

        public ResponseData<string> CheckEmailRegisterd(string email)
        {
            var userEmail = _userQuery.GetUserByEmail(email) == null ? string.Empty : email;

            return new ResponseData<string>()
            {
                Success = userEmail != string.Empty,
                Data = userEmail
            };
        }
    }
}
