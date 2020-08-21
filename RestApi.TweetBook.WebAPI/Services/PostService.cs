using System;
using System.Collections.Generic;
using System.Linq;
using RestApi.TweetBook.WebAPI.Domain;

namespace RestApi.TweetBook.WebAPI.Services
{
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

        public bool Update(Post post)
        {
            var exist = GetById(post.Id) != null;

            if (!exist) return false;

            var index = _posts.FindIndex(x => x.Id == post.Id);
            _posts[index] = post;
            return true;
        }

        public bool Delete(Guid id)
        {
            var post = GetById(id);

            if (post is null) return false;
            _posts.Remove(post);

            return true;
        }

        #endregion
    }
}