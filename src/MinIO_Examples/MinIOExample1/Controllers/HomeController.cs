using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MinIOExample1.Data;
using MinIOExample1.Interfaces;
using MinIOExample1.Models;

namespace MinIOExample1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFileOperation _fileOperations;
        private readonly MinIODbContext _dbContext;

        public HomeController(
            ILogger<HomeController> logger,
            IFileOperation fileOperations,
            MinIODbContext dbContext)
        {
            _logger = logger;
            _fileOperations = fileOperations;
            _dbContext = dbContext;
        }

        #region minIO actions

        [HttpGet]
        public async Task<IActionResult> MinIOIndex()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> MinIOIndex(IFormFile file)
        {
            var key = await _fileOperations.UploadFile(file);

            var entity = new File
            {
                ContentType = file.ContentType,
                Key = key,
                Name = file.FileName
            };

            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return View();
        }


        public IActionResult AllImages()
        {
            var images = _dbContext.Files.Where(f => f.ContentType == "image/png").ToList();
            var files = new List<string>();
            images.ForEach(im => files.Add(_fileOperations.GetFile(im.Key).Replace("https", "http")));
            return View(files);
        }
        public IActionResult AllPdf()
        {
            var images = _dbContext.Files.Where(f => f.ContentType == "application/pdf").ToList();
            var files = new Dictionary<string, string>();
            images.ForEach(im => files.Add(_fileOperations.GetFile(im.Key), im.Name));
            return View(files);
        }

        #endregion






        public IActionResult Index()
        {
            return View();
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
