using System;
using System.ComponentModel.DataAnnotations;
using LibraryClass.Models.ViewModels.User;

namespace LibraryClass.Models.Entities
{
	public class User
	{
        
            public User() { }

            public User(UserAddVM src)
            {
                Id = src.Id;
                FirstName = src.FirstName;
                LastName = src.LastName;
                Email = src.Email;
                Phone = src.Phone;
                StreetAddress = src.StreetAddress;
                City = src.City;
                Province = src.Province;
        }

            public User(UserUpdateVM src)
            {
                Id = src.Id;
                FirstName = src.FirstName;
                LastName = src.LastName;
                Phone = src.Phone;
                StreetAddress = src.StreetAddress;
                City = src.City;
                Province = src.Province;
        }

            [Required]
            [Key]
            public string Id { get; set; } = String.Empty;

            [Required]
            public string FirstName { get; set; } = String.Empty;

            [Required]
            public string LastName { get; set; } = String.Empty;

            [Required]
            public string Email { get; set; } = String.Empty;

            [Required]
            public string Phone { get; set; } = String.Empty;

           [Required]
           public string StreetAddress { get; set; } = String.Empty;

           [Required]
           public string City { get; set; } = String.Empty;

           [Required]
           public string Province { get; set; } = String.Empty;

        //Country


        //product user relationships
        public ICollection<Product> Products { get; set; } = new List<Product>(); //a user can have many products

        }
    }

