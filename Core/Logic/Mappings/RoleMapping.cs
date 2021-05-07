using AutoMapper;

namespace Logic.Mappings
{
    public class RoleMapping : Profile
    {
        public RoleMapping()
        {
            CreateMap<Domain.Role, DTOs.Role>();

            CreateMap<DTOs.Role, Domain.Role>();
        }
    }
}