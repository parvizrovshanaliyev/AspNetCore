using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MinIOExample1.Interfaces
{
    public interface IFileOperation
    {
        Task<string> UploadFile(IFormFile file);
        string GetFile(string key);
    }

    public class FileOperation : IFileOperation
    {
        private IConfiguration Configuration { get; set; }
        private ILogger<FileOperation> Logger { get; set; }
        private string minioSecretkey => Configuration["MinioAccessInfo:SecretKey"];
        private string minIoPassword => Configuration["MinioAccessInfo:Password"];
        private string minIoEndPoint => Configuration["MinioAccessInfo:EndPoint"];
        private string bucketName => Configuration["MinioAccessInfo:BucketName"];
        private readonly AmazonS3Client _client;

        public FileOperation(IConfiguration Configuration, ILogger<FileOperation> logger)
        {
            this.Configuration = Configuration;
            this.Logger = logger;
            var config = new AmazonS3Config
            {
                RegionEndpoint = RegionEndpoint.GetBySystemName("us-east-1"),
                ServiceURL = minIoEndPoint,
                ForcePathStyle = true,
                SignatureVersion = "2"
            };
            _client = new AmazonS3Client(minioSecretkey, minIoPassword, config);
        }

        #region Implementation of IFileOperations

        public  async Task<string> UploadFile(IFormFile file)
        {
            var key = String.Empty;
            try
            {
                key = Guid.NewGuid().ToString();
                var stream = file.OpenReadStream();
                var request = new PutObjectRequest()
                {
                    BucketName = bucketName,
                    InputStream = stream,
                    AutoCloseStream = true,
                    Key = key,
                    ContentType = file.ContentType
                };
                var encodedFilename = Uri.EscapeDataString(file.FileName);
                request.Metadata.Add("original-filename", encodedFilename);
                request.Headers.ContentDisposition = $"attachment; filename=\"{encodedFilename}\"";
                await _client.PutObjectAsync(request);
            }
            catch (Exception e)
            {
                Logger.LogError("Error ocurred In UploadFileAsync", e);
            }
            return key;
        }

        

        public string GetFile(string key)
        {
            if (string.IsNullOrEmpty(key)) return null;

            return _client.GetPreSignedURL(new GetPreSignedUrlRequest()
            {
                BucketName = bucketName,
                Key = key,
                Expires = DateTime.Now.AddMinutes(30)
            });
        }

        #endregion
    }
   
    
}
