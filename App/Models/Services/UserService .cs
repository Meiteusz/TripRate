using Models.DTO_s.Responses;
using Models.Queries.Interfaces;

namespace Models
{
    public class UserService : IUserService
    {
        private readonly IUserQuery UserQuery;

        public UserService(IUserQuery userQuery)
        {
            this.UserQuery = userQuery;
        }

        public ResponseData<User> LoginByEmailAndPassword(string email, string password)
        {
            var user = User.GetFirstOrDefault(email, password);

            if (user == null)
                return new ResponseData<User>(); //throw a Custom Exception

            return new ResponseData<User>()
            {
                Success = true,
                Message = "Logged Succeffuly",
                Data = user
            };
        }

        public ResponseData<string> CheckEmailRegisterd(string email)
        {
            var userEmail = UserQuery.GetUserByEmail(email) == null ? string.Empty : email;

            return new ResponseData<string>()
            {
                Success = userEmail != string.Empty,
                Data = userEmail
            };
        }
    }
}
