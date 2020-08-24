using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.TweetBook.WebAPI.Contracts.Requests
{
    public class UpdatePostRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
