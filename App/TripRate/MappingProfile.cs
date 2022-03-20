using AutoMapper;
using Models;
using Models.DTO_s.Entities;
using TripRate.Models;

namespace TripRate
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, ModelUser>().ReverseMap();
            CreateMap<Trip, ModelTrip>().ReverseMap();
        }
    }
}
