using System.Threading;
using System.Threading.Tasks;
using Application.Logic;
using MediatR;

namespace Application.Requests.Post
{
    public class UpdatePostRequest : IRequest<DTOs.Post>
    {
        public DTOs.Post Post { get; set; } = null!;
        
        public class Handler : IRequestHandler<UpdatePostRequest, DTOs.Post>
        {
            private readonly IPostService _service;

            public Handler(IPostService service)
            {
                _service = service;
            }

            public Task<DTOs.Post> Handle(UpdatePostRequest request, CancellationToken cancellationToken)
            {
                return _service.Update(request.Post);
            }
        }
    }
}