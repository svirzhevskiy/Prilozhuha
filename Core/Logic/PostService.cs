using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Logic;
using AutoMapper;
using Database;
using DTOs;
using Microsoft.EntityFrameworkCore;

namespace Logic
{
    public class PostService : GenericService<Domain.Post, Post>, IPostService
    {
        public PostService(AppDbContext context, IMapper mapper) : base(context, mapper) {}

        public async Task<List<Post>> GetByTags(List<string> tags)
        {
            var query = _targetSet.Where(x => !x.IsDeleted && tags.All(y => x.Tags.Contains(y)));

            return await _mapper.ProjectTo<Post>(query).ToListAsync();
        }
    }
}