using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RestApi.TweetBook.WebAPI.Contracts.V1;
using RestApi.TweetBook.WebAPI.Domain;

namespace RestApi.TweetBook.WebAPI.Controllers.V1
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class PostsController : ControllerBase
    {
        private List<Post> _postList;

        public PostsController()
        {
            _postList = new List<Post>();
            for (int i = 0; i < 5; i++)
            {
                _postList.Add(new Post { Id = Guid.NewGuid().ToString() });
            }
        }

        [HttpGet(ApiRoutes.Posts.GetAll)]
        public IActionResult GetAll() => Ok(_postList);
    }
}
