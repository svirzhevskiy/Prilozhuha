using System.Linq;
using AutoMapper;

namespace Logic.Mappings
{
    public class PostMapping : Profile
    {
        public PostMapping()
        {
            CreateMap<Domain.Post, DTOs.Post>()
                .ForMember(x => x.Tags, y => y.MapFrom(s => s.Tags.ToList()))
                .ReverseMap();
        }
    }
}