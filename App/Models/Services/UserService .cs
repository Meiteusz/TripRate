using Models.DTO_s.Responses;

namespace Models
{
    public class UserService : IUserService
    {
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
    }
}
