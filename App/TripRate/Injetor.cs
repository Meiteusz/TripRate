using Controllers;
using Microsoft.Extensions.DependencyInjection;
using Models;

namespace TripRate
{
    public static class Injetor
    {
        public static void InjectService(IServiceCollection service)
        {
            service.AddScoped<IUserController, UserController>();
            service.AddScoped<IUserService, UserService>();
        }
    }
}
