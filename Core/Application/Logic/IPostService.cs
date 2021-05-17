using System.Collections.Generic;
using System.Threading.Tasks;
using DTOs;

namespace Application.Logic
{
    public interface IPostService : IGenericService<Domain.Post, DTOs.Post>
    {
        public Task<List<Post>> GetByTags(List<string> tags);
    }
}