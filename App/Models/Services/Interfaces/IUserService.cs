using Models.DTO_s.Responses;

namespace Models
{
    public interface IUserService
    {
        ResponseData<User> LoginByEmailAndPassword(string email, string password);
    }
}