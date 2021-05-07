using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Logic;

namespace Application.Requests.Post
{
    public class GetAllPostsRequest : IRequest<List<DTOs.Post>>
    {
        public class Handler : IRequestHandler<GetAllPostsRequest, List<DTOs.Post>>
        {
            private readonly IPostService _service;
    
            public Handler(IPostService service)
            {
                _service = service;
            }
    
            public Task<List<DTOs.Post>> Handle(GetAllPostsRequest request, CancellationToken cancellationToken = default)
            {
                return _service.GetAll();
            }
        }
    }

    
}