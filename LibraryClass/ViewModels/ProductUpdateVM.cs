using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryClass.Models.ViewModels
{
	public class ProductUpdateVM // contains just the fields that are allow to be updated
	{

        [Key]
        public Guid Id { get; set; } // in this case we include the gui

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;

        [Required]
        public string City { get; set; } = string.Empty;

      //  [Required] 
     //   public DateTime Created { get; set; }

        [Required]
        public decimal Price { get; set; }

    }
}

