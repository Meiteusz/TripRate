using Models;
using System;

namespace Controllers
{
    public class UserController : IUserController
    {
        public User CreateInstance() => User.CreateInstance();

        public Response RegisterUser(User user)
        {
            return user.Save();
        }
    }
}
