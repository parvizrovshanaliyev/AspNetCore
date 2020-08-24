using Microsoft.AspNetCore.Mvc;
using RestApi.TweetBook.WebAPI.Services;

namespace RestApi.TweetBook.WebAPI.Controllers.V1
{
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityService _identityService;

        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }
    }
}
