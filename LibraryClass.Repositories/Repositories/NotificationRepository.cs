using System;
using LibraryClass.Models.Entities;
using LibraryClass.Repositories.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using LibraryClass.Shared.Exceptions;

namespace LibraryClass.Repositories.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly ApplicationDbContext _context;

        public NotificationRepository (ApplicationDbContext context)
        {
            _context = context;
        }

        // Create a new game
        public void Create(Notification entity) //should match the var from the entity file
        {
            // Add the created date
            entity.Created = DateTime.UtcNow;

            // Perform the add in memory
            _context.Add(entity);
        }

        // Get a single existing game by Id
        public async Task<Notification> GetById(Guid id)
        {
            // Get the entity
            var result = await _context.Notifications.FirstOrDefaultAsync(i => i.Id == id);
            if (result == null)
                throw new NotFoundException("The requested game was not found");

            return result;
        }

        // Get all of the games
        public async Task<List<Notification>> GetAll()
        {
            // Get all the entities
            var results = await _context.Notifications.ToListAsync();

            // Return the retrieved entities
            return results;
        }

        // Update an existing game
        public void Update(Notification entity)
        {
            // Update the entity
            _context.Update(entity);
        }

        // Delete a game
        public void Delete(Notification entity)
        {
            // Delete the entity
            _context.Remove(entity);
        }
    }
}
