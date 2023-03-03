using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryClass.Models.ViewModels.Upload;
using LibraryClass.Services.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MainProject.API.Controllers
{
    public class UploadController : Controller
    {
        private readonly IUploadService _uploadService;

        /// <summary>
        /// Constructor for Dependency Injection
        /// </summary>
        /// <param name="uploadService"></param>
        public UploadController(IUploadService uploadService)
        {
            _uploadService = uploadService;
        }

        /// <summary>
        /// Upload 1 or more files
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<List<UploadResultVM>>> UploadImage()
        {
            // Validate the file types
            var supportedTypes = new[] { ".png", ".gif", ".jpg", ".jpeg" };
            var uploadedExtensions = Request.Form.Files.Select(i => System.IO.Path.GetExtension(i.FileName));
            var mismatchFound = uploadedExtensions.Any(i => !supportedTypes.Contains(i));
            if (mismatchFound)
                return BadRequest(new { message = "At least one uploaded file is not a valid image type" });
            var results = await _uploadService.UploadFiles(Request.Form.Files.ToList());
            return Ok(results);
        }
    }
}
