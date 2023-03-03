using System;
using LibraryClass.Models.ViewModels.Upload;
using Microsoft.AspNetCore.Http;

namespace LibraryClass.Services.Services.Interfaces
{
	public interface IUploadService
	{
		Task<List<UploadResultVM>> UploadFiles(List<IFormFile> files);
	}
}

