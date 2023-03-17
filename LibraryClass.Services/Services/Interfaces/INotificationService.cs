using System;
using LibraryClass.Models.Entities;
using LibraryClass.Models.ViewModels;
using LibraryClass.Models.ViewModels.Notifications;
using LibraryClass.Repositories.Repositories;

namespace LibraryClass.Services.Services.Interfaces
{
    public interface INotificationService { }
/*
    {//from view models
        Task<NotificationVM> Create(NotificationAddVM src, string userId);     // Create a new game // relation with user
        Task<NotificationVM> GetById(Guid id);          // Get a single existing game by Id
        Task<List<NotificationVM>> GetAll();            // Get all of the games
        Task<NotificationVM> Update(NotificationUpdateVM src);  // Update an existing game
        Task Delete(Guid id);                   // Delete a game
    }*/
}
