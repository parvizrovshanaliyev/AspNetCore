﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestApi.TweetBook.WebAPI.Contracts.Requests;
using RestApi.TweetBook.WebAPI.Contracts.Responses;
using RestApi.TweetBook.WebAPI.Contracts.V1;
using RestApi.TweetBook.WebAPI.Domain;
using RestApi.TweetBook.WebAPI.Services;

namespace RestApi.TweetBook.WebAPI.Controllers.V1
{
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet(ApiRoutes.Posts.GetAll)]
        public async Task<IActionResult> GetAll() => Ok(await _postService.GetAllAsync());


        [HttpGet(ApiRoutes.Posts.Get)]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var post = await _postService.GetByIdAsync(id);
            if (post is null)
                return NotFound();
            return Ok(post);
        }

        [HttpPost(ApiRoutes.Posts.Create)]
        public async Task<IActionResult> Create([FromBody] CreatePostRequest request)
        {
            var post = new Post { Name = request.Name };
            await _postService.CreateAsync(post);
            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = $"{baseUrl}/{ApiRoutes.Posts.Get.Replace("{Id}", post.Id.ToString())}";

            var response = new PostResponse { Id = post.Id };
            return Created(locationUri, response);
        }


        [HttpPut(ApiRoutes.Posts.Update)]
        public async Task<IActionResult> Update([FromBody] UpdatePostRequest request)
        {
            var post = new Post
            {
                Id = request.Id,
                Name = request.Name
            };

            var updated = await _postService.UpdateAsync(post);

            if (updated)
                return Ok();
            return NotFound();
        }

        [HttpDelete(ApiRoutes.Posts.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var removed = await _postService.Delete(id);

            if (removed)
                return NoContent();
            return NotFound();
        }
    }
}
