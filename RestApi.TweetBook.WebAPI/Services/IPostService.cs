using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestApi.TweetBook.WebAPI.Domain;

namespace RestApi.TweetBook.WebAPI.Services
{
    public interface IPostService
    {
        Task<List<Post>> GetAllAsync();
        Task<Post> GetByIdAsync(Guid id);

        Task<bool> CreateAsync(Post post);
        Task<bool> UpdateAsync(Post post);
        Task<bool> Delete(Guid id);
    }
}
