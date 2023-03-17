using System;
using LibraryClass.Models.Entities;

namespace LibraryClass.Models.ViewModels.Notifications
{
	public class NotificationVM
    {
        // Default constructor to allow creation of an empty ListingVM
        public NotificationVM() { }

        // Constructor for populating a new ListingVM from a Listing entity
        public NotificationVM(Notification src)
        {
            Id = src.Id;
            Message = src.Message;
            IsRead = src.IsRead;
        
          //  Created = src.Created;
         
        }

        public Guid Id { get; set; }

        public string UserId { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;

        public bool IsRead { get; set; } 
      

      //  public DateTime Created { get; set; }

   
    }

}