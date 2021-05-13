using System;
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
        public Task<List<Post>> GetAll([FromQuery]List<string> tags) 
            => _mediator.Send(new GetAllPostsRequest {Tags = tags});

        [HttpPost]
        public Task<Post> Create(Post model) 
            => _mediator.Send(new CreatePostRequest {Post = model});

        [HttpGet("{id:guid}")]
        public Task<Post> GetById(Guid id) 
            => _mediator.Send(new GetPostRequest {PostId = id});

        [HttpPut]
        public Task<Post> Update(Post model) 
            => _mediator.Send(new UpdatePostRequest {Post = model});

        [HttpDelete("{id:guid}")]
        public Task Delete(Guid id) 
            => _mediator.Send(new DeletePostRequest {PostId = id});
    }
}