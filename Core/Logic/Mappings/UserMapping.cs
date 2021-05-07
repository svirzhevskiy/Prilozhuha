using AutoMapper;

namespace Logic.Mappings
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<Domain.User, DTOs.User>()
                .ForMember(x => x.Posts, y => y.Ignore());

            CreateMap<DTOs.User, Domain.User>()
                .ForMember(x => x.RoleId, y => y.MapFrom(s => s.Role.Id))
                .ForMember(x => x.Role, y => y.Ignore());
        }
    }
}