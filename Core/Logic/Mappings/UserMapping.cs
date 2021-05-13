using AutoMapper;

namespace Logic.Mappings
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<Domain.User, DTOs.User>().ReverseMap();
        }
    }
}