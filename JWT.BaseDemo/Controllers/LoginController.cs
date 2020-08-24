using System;
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
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        readonly ApplicationDbContext _context;
        readonly IConfiguration _configuration;
        public LoginController(ApplicationDbContext content, IConfiguration configuration)
        {
            _context = content;
            _configuration = configuration;
        }
        [HttpPost("create")]
        public async Task<User> Create([FromBody] User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }
        [HttpPost("authenticate")]
        public async Task<Token> Authenticate([FromBody] AuthenticateRequest request)
        {
            User user = await _context.Users.FirstOrDefaultAsync(x => x.Username == request.Username && x.Password == request.Password);
            if (user == null) return null;
            //Token üretiliyor.
            TokenHandler tokenHandler = new TokenHandler(_configuration);
            Token token = tokenHandler.CreateAccessToken(user);

            //Refresh token Users tablosuna işleniyor.
            user.RefreshToken = token.RefreshToken;
            user.RefreshTokenEndDate = token.Expiration.AddMinutes(3);
            await _context.SaveChangesAsync();

            return token;
        }

        [HttpGet("refreshToken")]
        public async Task<Token> RefreshToken([FromForm] string refreshToken)
        {
            User user = await _context.Users.FirstOrDefaultAsync(x => x.RefreshToken == refreshToken);
            if (user == null || !(user?.RefreshTokenEndDate > DateTime.Now)) return null;
            TokenHandler tokenHandler = new TokenHandler(_configuration);
            Token token = tokenHandler.CreateAccessToken(user);

            user.RefreshToken = token.RefreshToken;
            user.RefreshTokenEndDate = token.Expiration.AddMinutes(3);
            await _context.SaveChangesAsync();

            return token;
        }
    }
    
    [Microsoft.AspNetCore.Authorization.Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        public string Index()
        {
            return "Yetkilendirme başarılı...";
        }
    }
}
