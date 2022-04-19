using AutoMapper;
using Models;
using Models.Entities;
using TripRate.Models;

namespace TripRate
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, ModelUser>().ReverseMap();
            CreateMap<ReviewTrip, ModelTrip>().ReverseMap();
            CreateMap<Hotel, ModelHotel>().ReverseMap();
        }
    }
}
