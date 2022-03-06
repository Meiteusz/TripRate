using Controllers;
using Microsoft.Extensions.DependencyInjection;
using Models;
using Models.Queries;
using Models.Queries.Interfaces;

namespace TripRate
{
    public static class Injetor
    {
        public static void InjectService(IServiceCollection service)
        {
            service.AddScoped<IUserController, UserController>();
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IUserQuery, UserQuery>();
        }
    }
}
