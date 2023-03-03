using System;
using Amazon.S3;
using Amazon.S3.Transfer;
using LibraryClass.Models.Entities;
using LibraryClass.Models.ViewModels.Upload;
using LibraryClass.Repositories.Repositories;
using LibraryClass.Services.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace LibraryClass.Services.Services
{
    public class UploadService : IUploadService
    {
        private readonly IConfiguration _config;
        private readonly IUnitOfWork _uow;

        public UploadService(IConfiguration config, IUnitOfWork uow)
        {
            _config = config;
            _uow = uow;
        }

        public async Task<List<UploadResultVM>> UploadFiles(List<IFormFile> files)
        {
            var results = new List<UploadResultVM>();

            // Iterate over all the files
            foreach (var file in files)
            {
                var newId = Guid.NewGuid();
                var bucket = _config.GetSection("AWS").GetValue<string>("ImageBucket");
                var region = _config.GetSection("AWS").GetValue<string>("Region");

                // Perform the upload to S3
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);

                    // Upload the file
                    var s3Client = new AmazonS3Client(Amazon.RegionEndpoint.GetBySystemName(region));
                    var fileTransfer = new TransferUtility(s3Client);
                    await fileTransfer.UploadAsync(memoryStream, bucket, newId.ToString());
                }

                // Store the file info for reference by other entities
                _uow.Uploads.Create(new Upload
                {
                    Id = newId,
                    Url = $"https://{bucket}.s3.{region}.amazonaws.com/{newId}"
                });
                await _uow.SaveAsync();

                // Build our response object
                results.Add(new UploadResultVM
                {
                    Id = newId
                });
            }

            return results;
        }
    }
}
