using System;
namespace LibraryClass.Models.ViewModels.Upload
{
    /// <summary>
    /// Result of a file upload
    /// </summary>
    public class UploadResultVM
    {
        /// <summary>
        /// Id of the uploaded file
        /// </summary>
        public Guid Id { get; set; }

      //  public string FileName { get; set; } = string.Empty; // which one is the correct
    }
}

