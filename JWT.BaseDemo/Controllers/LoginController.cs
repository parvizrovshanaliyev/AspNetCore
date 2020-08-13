using System.Threading.Tasks;
using JWT.BaseDemo.Data;
using JWT.BaseDemo.Entities;
using JWT.BaseDemo.Helpers;
using JWT.BaseDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace JWT.BaseDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        readonly ApplicationDbContext _context;
        readonly IConfiguration _configuration;
        public LoginController(ApplicationDbContext content, IConfiguration configuration)
        {
            _context = content;
            _configuration = configuration;
        }
        [HttpPost("[action]")]
        public async Task<bool> Create([FromForm] User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }
        [HttpPost("action")]
        public async Task<Token> Login([FromForm] AuthenticateRequest request)
        {
            User user = await _context.Users.FirstOrDefaultAsync(x => x.Email == request.Username && x.Password == request.Password);
            if (user != null)
            {
                //Token üretiliyor.
                TokenHandler tokenHandler = new TokenHandler(_configuration);
                Token token = tokenHandler.CreateAccessToken(user);

                //Refresh token Users tablosuna işleniyor.
                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenEndDate = token.Expiration.AddMinutes(3);
                await _context.SaveChangesAsync();

                return token;
            }
            return null;
        }
    }
    
    [Microsoft.AspNetCore.Authorization.Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        public string Index()
        {
            return "Yetkilendirme başarılı...";
        }
    }
}
