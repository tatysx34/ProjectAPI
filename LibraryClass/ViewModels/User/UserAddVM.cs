using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryClass.Models.ViewModels.User
{
    public class UserAddVM
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string FirstName { get; set; } = String.Empty;

        [Required]
        public string LastName { get; set; } = String.Empty;

        [Required]
        public string Email { get; set; } = String.Empty;

        [Required]
        public string Phone { get; set; } = String.Empty;
    }
}

