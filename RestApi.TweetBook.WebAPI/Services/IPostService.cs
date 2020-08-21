﻿using System;
using System.Collections.Generic;
using System.Linq;
using RestApi.TweetBook.WebAPI.Domain;

namespace RestApi.TweetBook.WebAPI.Services
{
    public interface IPostService
    {
        List<Post> GetAll();
        Post GetById(Guid id);
    }

    public class PostService : IPostService
    {
        private  List<Post> _posts;

        public PostService()
        {
            _posts = new List<Post>();
            for (int i = 0; i < 5; i++)
            {
                _posts.Add(new Post
                {
                    Id = Guid.NewGuid(),
                    Name = $"Post name {i}"
                });
            }
        }
        #region Implementation of IPostService

        public List<Post> GetAll()
        {
            return _posts;
        }

        public Post GetById(Guid id)
        {
            return _posts.SingleOrDefault(x => x.Id == id);
        }

        #endregion
    }
}
