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
                .ForMember(x => x.Author, y => y.MapFrom(s => s.Author))
                .ForPath(x => x.Author.Posts, y => y.Ignore());

            CreateMap<DTOs.Post, Domain.Post>()
                .ForMember(x => x.Tags, y => y.MapFrom(s => s.Tags.ToArray()))
                .ForMember(x => x.AuthorId, y => y.MapFrom(s => s.Author.Id))
                .ForMember(x => x.Author, y => y.Ignore());
        }
    }
}