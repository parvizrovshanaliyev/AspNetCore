using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CRUDAPI.WEB.Helper
{
    public class StudentApi
    {
        public HttpClient Initial()
        {
            var client = new HttpClient {BaseAddress = new Uri("https://localhost:44323/") };
            return client;
        }
    }
}
