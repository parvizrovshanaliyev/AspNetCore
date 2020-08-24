using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDAPI.WEB.Models
{
    public class LoginModel
    {
        public string compId { get; set; }
        public Guid requestNumber { get; set; }
        public string username { get; set; }
        public string userpassword { get; set; }
    }
}
