using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Logic;
using MediatR;

namespace Application.Requests.User
{
    public class GetUserRequest : IRequest<DTOs.User>
    {
        public Guid UserId { get; set; }
        
        public class Handler : IRequestHandler<GetUserRequest, DTOs.User>
        {
            private readonly IGenericService<Domain.User, DTOs.User> _service;

            public Handler(IGenericService<Domain.User, DTOs.User> service)
            {
                _service = service;
            }

            public Task<DTOs.User> Handle(GetUserRequest request, CancellationToken cancellationToken)
            {
                return _service.GetById(request.UserId);
            }
        }
    }
}