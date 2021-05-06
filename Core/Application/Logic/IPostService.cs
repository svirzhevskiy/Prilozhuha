using System.Collections.Generic;
using System.Threading.Tasks;
using DTOs;

namespace Application.Logic
{
    public interface IPostService : IGenericService<Post>
    {
        public Task<List<Post>> GetByTags(List<string> tags);
    }
}