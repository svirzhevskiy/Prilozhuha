using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Requests.User;
using DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class UserController : BaseController
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id:guid}")]
        public Task<User> GetById(Guid id)
            => _mediator.Send(new GetUserRequest {UserId = id});

        [HttpGet]
        public Task<List<User>> GetAll()
            => _mediator.Send(new GetAllUsersRequest());
    }
}