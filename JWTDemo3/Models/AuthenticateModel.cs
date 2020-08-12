using System.ComponentModel.DataAnnotations;

namespace JWTDemo3.Models
{
    //Authenticate işleminde neler geleceğini ve validasyonları için oluşturdum.
    public class AuthenticateModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
