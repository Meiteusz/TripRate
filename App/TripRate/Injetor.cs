using Controllers;
using Controllers.Interfaces;
using Controllers.Services;
using Controllers.Services.Interfaces;
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

            service.AddScoped<ITripReviewController, TripReviewController>();
            service.AddScoped<ITripService, TripService>();
            service.AddScoped<ITripReviewQuery, TripReviewQuery>();

            service.AddScoped<IHotelController, HotelController>();
            service.AddScoped<IHotelService, HotelService>();
            service.AddScoped<IHotelQuery, HotelQuery>();

            service.AddScoped<IEmailSender, EmailSender>();
        }
    }
}
