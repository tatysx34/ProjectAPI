using System;
using System.ComponentModel.DataAnnotations;
using LibraryClass.Models.ViewModels;

namespace LibraryClass.Models.Entities
{
    public class Product

    {
        //default constructor to allow the creation of an empty entity 
        public Product()
        {
        }
        //constuctor use to create a new game from the ProjectAddVM model
        public Product(ProjectAddVM src, String userId)
        {
             UserId = userId; // added relationships

            Title = src.Title;
            Description = src.Description;
            Price = src.Price;
            Address = src.Address;
            City = src.City;

            Created = DateTime.UtcNow; //this is add after relationships

        }


        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;

        [Required]
        public string City { get; set; } = string.Empty;

        [Required]
        public DateTime Created { get; set; }

        [Required]
        public decimal Price { get; set; }


        // relationships
        [Required]
        public string UserId { get; set; } = String.Empty;

        public User? User { get; set; } 










    }
}

