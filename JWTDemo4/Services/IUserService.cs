using System.Collections.Generic;
using JWTDemo4.Entities;
using JWTDemo4.Models;

namespace JWTDemo4.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }
}
