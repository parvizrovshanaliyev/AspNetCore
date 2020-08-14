using Microsoft.AspNetCore.Mvc;

namespace RestApi.TweetBook.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        /// <summary>
        /// get
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new {name = "parviz"});
        }
    }
}