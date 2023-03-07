using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryClass.Models.ViewModels.User
{
    public class UserVM
    {
        public UserVM(Entities.User src)
        {
            Id = src.Id;
            FirstName = src.FirstName;
            LastName = src.LastName;
            Email = src.Email;
            Phone = src.Phone;
        }

        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string StreetAddress { get; set; } 

        public string City { get; set; }

        public string Province { get; set; } 
    }
}

