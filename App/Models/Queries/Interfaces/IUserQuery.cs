namespace Models.Queries.Interfaces
{
    public interface IUserQuery
    {
        User GetUserByEmail(string email);
    }
}
