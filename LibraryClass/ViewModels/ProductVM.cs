using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibraryClass.Models.Entities;
namespace LibraryClass.Models.ViewModels
{
    public class ProductVM

    {
        // Default constructor to allow creation of an empty ListingVM
        public ProductVM() { }

        // Constructor for populating a new ListingVM from a Listing entity
        public ProductVM(Product src) 
        {
            Id = src.Id;
            Title = src.Title;
            Description = src.Description;
            Created = src.Created;
            Price = src.Price;
            Address = src.Address;
            City = src.City;
            UserId = src.UserId;  //relational
        }

        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public DateTime Created { get; set; }

        public decimal Price { get; set; }

        //relational
        public string UserId { get; set; }
    }

}