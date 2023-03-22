using System;
using LibraryClass.Models.Entities;
using LibraryClass.Repositories.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryClass.Repositories.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Create a new user
        public void Create(User entity)
        {
            // Perform the add in memory
            _context.Add(entity);
        }

        // Get a single user by Id
        // Note: Will return null if user doesn't exist
        public async Task<User> GetById(string id)
        {
            // Get the entity
            var result = await _context.Users.FirstAsync(i => i.Id == id);

            // Return the retrieved entity
            return result;
        }

        // Update an existing user
        public void Update(User entity)
        {
            // Update the entity
            _context.Update(entity);
        }

        //api/user/contactus endpoint

        
    }
}

