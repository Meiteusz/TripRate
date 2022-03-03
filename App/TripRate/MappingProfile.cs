using AutoMapper;
using Models;
using TripRate.Models;

namespace TripRate
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, ModelUser>().ReverseMap();
        }
    }
}
