using System;
using LibraryClass.Models.Entities;

namespace LibraryClass.Repositories.Repositories.Interfaces
{
	public interface INotificationRepository
    {                             //should match with the entity file name
        
            void Create(Notification entity);         // Create a new game
            Task<Notification> GetById(Guid id);      // Get a single existing game by Id
            Task<List<Notification>> GetAll();        // Get all of the games
            void Update(Notification entity);         // Update an existing game
            void Delete(Notification entity);         // Delete a game
        }
    }
