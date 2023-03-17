using System;
using LibraryClass.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace LibraryClass.Models.Entities
{
    public class Notification

    {
        //default constructor to allow the creation of an empty entity 
        public Notification()
        {
        }
        //I am not going to ask the frontend so I maybe not need this
       // public Notification(NotificationAddVM src, String userId)
       // {
       //     UserId = userId; // added relationships

       //     Message = src.Message;
            
       //     IsRead = src.IsRead;

         // Created = DateTime.UtcNow; //this is add after relationships

      //  }


        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Message { get; set; } = string.Empty;

        [Required]
        public bool IsRead { get; set; }



        [Required]
        public DateTime Created { get; set; }

      

        // relationships
       // [Required]
      //  public string UserId { get; set; } = String.Empty;

     //   public User? User { get; set; }

        //public string Notification { get; internal set; }
    }
}
