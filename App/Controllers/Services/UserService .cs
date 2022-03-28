using Controllers.Administration;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.DTO_s.Responses;
using Models.Queries.Interfaces;
using System;

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

            if (user.Id < 1)
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

        public Response UpdateUserSettings(User user)
        {
            try
            {
                using (var context = new TripRateContext())
                {
                    context.Entry(user).State = EntityState.Modified;

                    if (context.SaveChanges() > 0)
                    {
                        return new Response()
                        {
                            Success = true,
                            Message = "User updated successfully"
                        };
                    }
                    return new Response();
                }
            }
            catch (Exception ex)
            {
                return new Response()
                {
                    Message = ex.Message
                };
            }
        }
    }
}
