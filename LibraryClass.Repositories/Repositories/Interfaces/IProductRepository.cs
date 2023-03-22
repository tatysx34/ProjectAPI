using System;
using LibraryClass.Models.Entities;

namespace LibraryClass.Repositories.Repositories.Interfaces
{
	public interface IProductRepository
    {                             //should match with the entity file name
        
            void Create(Product entity);         // Create a new product
            Task<Product> GetById(Guid id);      // Get a single existing product by Id
            Task<List<Product>> GetAll();        // Get all of the products
            void Update(Product entity);         // Update an existing product
            void Delete(Product entity);         // Delete a product
            Task<List<Product>> GetBySearch();//(string searchItem); // to create search function
        }
    }
