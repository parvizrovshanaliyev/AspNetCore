using System;
using System.Collections.Generic;
using RestApi.TweetBook.WebAPI.Domain;

namespace RestApi.TweetBook.WebAPI.Services
{
    public interface IPostService
    {
        List<Post> GetAll();
        Post GetById(Guid id);

        bool Update(Post post);
        bool Delete(Guid id);
    }
}
