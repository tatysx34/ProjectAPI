using System;
using LibraryClass.Models.Entities;
using LibraryClass.Repositories.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using LibraryClass.Shared.Exceptions;

namespace LibraryClass.Repositories.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository (ApplicationDbContext context)
        {
            _context = context;
        }

        // Create a new game
        public void Create(Product entity) //should match the var from the entity file
        {
            // Add the created date
            entity.Created = DateTime.UtcNow;

            // Perform the add in memory
            _context.Add(entity);
        }

        // Get a single existing game by Id// pull out the database
        public async Task<Product> GetById(Guid id)  //get by search
        {
            // Get the entity
            var result = await _context.Products.FirstOrDefaultAsync(i => i.Id == id);
            if (result == null)
                throw new NotFoundException("The requested game was not found");

            return result;
        }

        // Get all of the games
        public async Task<List<Product>> GetAll()
        {
            // Get all the entities
            var results = await _context.Products.ToListAsync();

            // Return the retrieved entities
            return results;
        }

        // Update an existing game
        public void Update(Product entity)
        {
            // Update the entity
            _context.Update(entity);
        }

        // Delete a game
        public void Delete(Product entity)
        {
            // Delete the entity
            _context.Remove(entity);
        }

        // search repository
        // 
      // public async Task<Product> GetBySearch()//(string searchItem)  //get by search
      //  {
           
            public async Task<List<Product>> GetBySearch()
            {
            
                var results = await _context.Products.ToListAsync();

                // Return the retrieved entities
                return results;
            }



            /*// Get the entity
            var result = await _context.Products.FirstOrDefaultAsync(i => i.Title.Contains());//(searchItem));
            if (result == null)
                throw new NotFoundException("I am sorry we could not find any item with that name");

            return result;*/
        }
    }

