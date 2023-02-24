using System;
using LibraryClass.Models.Entities;

namespace LibraryClass.Repositories.Repositories.Interfaces
{
	public interface IProductRepository
    {                             //should match with the entity file name
        
            void Create(Product entity);         // Create a new game
            Task<Product> GetById(Guid id);      // Get a single existing game by Id
            Task<List<Product>> GetAll();        // Get all of the games
            void Update(Product entity);         // Update an existing game
            void Delete(Product entity);         // Delete a game
        }
    }
