using System;
using LibraryClass.Models.Entities;

namespace LibraryClass.Repositories.Repositories.Interfaces
{
    public interface IUserRepository
    {

        void Create(User entity);       // Create a new user
        Task<User> GetById(string id);  // Get a single user by Id
        void Update(User entity);       // Update an existing user

    }
}

