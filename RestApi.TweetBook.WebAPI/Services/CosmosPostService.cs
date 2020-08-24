using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestApi.TweetBook.WebAPI.Domain;

namespace RestApi.TweetBook.WebAPI.Services
{
    public class CosmosPostService : IPostService
    {
        #region Implementation of IPostService

        public Task<List<Post>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Post> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateAsync(Post post)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Post post)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
