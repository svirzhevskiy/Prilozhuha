using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Requests.Post;
using DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class PostController : BaseController
    {
        private readonly IMediator _mediator;

        public PostController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public Task<List<Post>> GetAll() => _mediator.Send(new GetAllPostsRequest());
    }
}