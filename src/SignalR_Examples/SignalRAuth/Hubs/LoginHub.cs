using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SignalRAuth.Data;
using SignalRAuth.Handlers;
using SignalRAuth.Interfaces;
using SignalRAuth.Models;

namespace SignalRAuth.Hubs
{
    public class LoginHub : Hub<ILoginHub>
    {
        readonly IConfiguration _configuration;
        readonly SignalRAuthDB _context;
        public LoginHub(IConfiguration configuration, SignalRAuthDB context)
        {
            _configuration = configuration;
            _context = context;
        }
        public async Task Create(string userName, string password)
        {
            await _context.Users.AddAsync(new User
            {
                Password = password,
                Username = userName
            });

            await Clients.Caller.Create(await _context.SaveChangesAsync() > 0);
        }
        public async Task Login(string userName, string password)
        {
            User user = await _context.Users.FirstOrDefaultAsync(u => u.Username == userName && u.Password == password);
            Token token = null;
            if (user != null)
            {
                TokenHandler tokenHandler = new TokenHandler(_configuration);
                token = tokenHandler.CreateAccessToken(5);
                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenEndDate = token.Expiration.AddMinutes(3);
                await _context.SaveChangesAsync();
            }
            await Clients.Caller.Login(user != null ? token : null);
        }
    }

    [Authorize]
    public class MessageHub : Hub<IMessageHub>
    {
        public async Task SendMessage(string message)
        {
            await Clients.Others.ReceiveMessage(message);
        }
    }
}
