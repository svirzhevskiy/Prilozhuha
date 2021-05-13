using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Logic;
using MediatR;

namespace Application.Requests.Post
{
    public class DeletePostRequest : IRequest
    {
        public Guid PostId { get; set; }
        
        public class Handler : IRequestHandler<DeletePostRequest>
        {
            private readonly IPostService _service;

            public Handler(IPostService service)
            {
                _service = service;
            }

            public Task<Unit> Handle(DeletePostRequest request, CancellationToken cancellationToken)
            {
                _service.Delete(request.PostId);

                return Unit.Task;
            }
        }
    }
}