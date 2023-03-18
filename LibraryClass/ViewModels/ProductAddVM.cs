using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryClass.Models.ViewModels
{
	public class ProductAddVM
	{
        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;

        [Required]
        public string City { get; set; } = string.Empty;

       // [Required]
       // public DateTime Created { get; set; }

        [Required]
        public decimal Price { get; set; }

    }
}

