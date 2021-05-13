using System.Threading;
using System.Threading.Tasks;
using Application.Logic;
using MediatR;

namespace Application.Requests.Post
{
    public class CreatePostRequest : IRequest<DTOs.Post>
    {
        public DTOs.Post Post { get; set; } = null!;
        
        public class Handler : IRequestHandler<CreatePostRequest, DTOs.Post>
        {
            private readonly IPostService _service;

            public Handler(IPostService service)
            {
                _service = service;
            }

            public Task<DTOs.Post> Handle(CreatePostRequest request, CancellationToken cancellationToken)
            {
                return _service.Create(request.Post);
            }
        }
    }
}