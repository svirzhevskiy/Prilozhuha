using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Logic;
using MediatR;

namespace Application.Requests.User
{
    public class GetAllUsersRequest : IRequest<List<DTOs.User>>
    {
        public class Handler : IRequestHandler<GetAllUsersRequest, List<DTOs.User>>
        {
            private readonly IGenericService<Domain.User, DTOs.User> _service;

            public Handler(IGenericService<Domain.User, DTOs.User> service)
            {
                _service = service;
            }

            public Task<List<DTOs.User>> Handle(GetAllUsersRequest request, CancellationToken cancellationToken)
            {
                return _service.GetAll();
            }
        }
    }
}