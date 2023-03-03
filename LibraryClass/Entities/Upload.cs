using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryClass.Models.Entities
{
    /// <summary>
    /// Entity for tracking uploaded files
    /// </summary>
    public class Upload
    {
        /// <summary>
        /// Upload Id
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Url of the file on S3
        /// </summary>
        [Required]
        public string Url { get; set; } = string.Empty;
    }
}