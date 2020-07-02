using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CRUDAPI.WEB.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CRUDAPI.WEB.Models;
using Newtonsoft.Json;
using RestSharp;

namespace CRUDAPI.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private StudentApi _api = new StudentApi();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Login()
        {
            LoginModel loginModel = new LoginModel
            {
                compId = "isb",
                username = "m-qanbarov@azersigorta-az.com",
                userpassword = "1234567",
                requestNumber = Guid.NewGuid()
            };
            string requestJson = JsonConvert.SerializeObject(loginModel);

            var client = new RestClient("https://api.isb.az/dispatcher/api/aas/loginApi") {Timeout = -1};
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");

            request.AddParameter("application/json", requestJson
                , ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);
            return View(response.Content);
        }

        public async Task<IActionResult> Index()
        {
            var studentList = new List<StudentData>();
            var client = _api.Initial();
            var res = await client.GetAsync("api/student");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                studentList = JsonConvert.DeserializeObject<List<StudentData>>(results);
            }

            return View(studentList);
        }

        public async Task<IActionResult> Details(int id)
        {
            var student = new StudentData();
            var client = _api.Initial();
            var res = await client.GetAsync($"api/student/{id}");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                student = JsonConvert.DeserializeObject<StudentData>(results);
            }

            return View(student);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(StudentData student)
        {
            var client = _api.Initial();

            // Http Post
            var postTask = client.PostAsJsonAsync<StudentData>("api/student", student);
            postTask.Wait();
            var result = postTask.Result;
            if (result.IsSuccessStatusCode) return RedirectToAction("Index");
            return View();
        }

        public async Task<IActionResult> DeleteAsync(int id)
        {
            var studentData= new StudentData();
            var client = _api.Initial();
            var res = await client.DeleteAsync($"api/student/{id}");
            return RedirectToAction("Index");
        }










        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
