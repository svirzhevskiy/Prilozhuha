using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Logic;
using MediatR;

namespace Application.Requests.Post
{
    public class GetPostRequest : IRequest<DTOs.Post>
    {
        public Guid PostId { get; set; }
        
        public class Handler : IRequestHandler<GetPostRequest, DTOs.Post>
        {
            private readonly IPostService _service;

            public Handler(IPostService service)
            {
                _service = service;
            }

            public Task<DTOs.Post> Handle(GetPostRequest request, CancellationToken cancellationToken)
            {
                return _service.GetById(request.PostId);
            }
        }
    }
}