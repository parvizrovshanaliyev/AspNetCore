using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RestApi.TweetBook.WebAPI.Contracts.Requests;
using RestApi.TweetBook.WebAPI.Contracts.Responses;
using RestApi.TweetBook.WebAPI.Contracts.V1;
using RestApi.TweetBook.WebAPI.Domain;
using RestApi.TweetBook.WebAPI.Services;

namespace RestApi.TweetBook.WebAPI.Controllers.V1
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet(ApiRoutes.Posts.GetAll)]
        public IActionResult GetAll() => Ok(_postService.GetAll());


        [HttpGet(ApiRoutes.Posts.Get)]
        public IActionResult Get([FromRoute] Guid id)
        {
            var post = _postService.GetById(id);
            if (post is null)
                return NotFound();
            return Ok(post);
        }

        [HttpPost(ApiRoutes.Posts.Create)]
        public IActionResult Create([FromBody] CreatePostRequest request)
        {
            var post = new Post { Id = request.Id };
            if (post.Id != Guid.Empty) post.Id = Guid.NewGuid();
            _postService.GetAll().Add(post);
            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = $"{baseUrl}/{ApiRoutes.Posts.Get.Replace("{Id}", post.Id.ToString())}";

            var response = new PostResponse { Id = post.Id };
            return Created(locationUri, response);
        }


        [HttpPut(ApiRoutes.Posts.Update)]
        public IActionResult Update([FromBody] UpdatePostRequest request)
        {
            var post = new Post
            {
                Id = request.Id,
                Name = request.Name
            };

            var updated = _postService.Update(post);

            if (updated)
                return Ok();
            return NotFound();
        }
    }
}
