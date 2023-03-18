using System;
using System.Linq;
using LibraryClass.Models.Entities;
using LibraryClass.Models.ViewModels;
using LibraryClass.Repositories.Repositories;
using LibraryClass.Services.Services.Interfaces;

namespace LibraryClass.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _uow;

        public ProductService(IUnitOfWork uow)
        {
            _uow = uow; //unit of work siglas
        }

        public async Task<ProductVM> Create(ProductAddVM src, string userId)
        {
            // Create the new Game entity
            var newEntity = new Product(src, userId);

            // Have the repository create the new game
            _uow.Products.Create(newEntity);
            await _uow.SaveAsync();

            // Create the GameVM we want to return to the client
            var model = new ProductVM(newEntity);

            // Return a GameVM
            return model;
        }

        public async Task<List<ProductVM>> GetAll()
        {
            // Get the Game entities from the repository
            var results = await _uow.Products.GetAll();

            // Build the GameVM view models to return to the client
            var models = results.Select(product => new ProductVM(product)).ToList();

            // Return the GameVMs
            return models;
        }
        // get by id search
        public async Task<ProductVM> GetById(Guid id)
        {
            // Get the requested Game entity from the repository
            var result = await _uow.Products.GetById(id);

            // Create the GameVM we want to return to the client
            var model = new ProductVM(result);

            // Return a 200 response with the GameVM
            return model;
        }

        public async Task<ProductVM> Update(ProductUpdateVM src)
        {
            // Get the existing entity
            var entity = await _uow.Products.GetById(src.Id);

            // Perform the update
            entity.Title = src.Title;
            entity.Description = src.Description;
            entity.Price = src.Price;
            entity.Address = src.Address;
            entity.City = src.City;

            // Have the repository update the game
            _uow.Products.Update(entity);
            await _uow.SaveAsync();

            // Create the GameVM we want to return to the client
            var model = new ProductVM(entity);

            // Return a 200 response with the GameVM
            return model;
        }

        public async Task Delete(Guid id)
        {
            // Get the existing entity
            var entity = await _uow.Products.GetById(id);

            // Tell the repository to delete the requested Game entity
            _uow.Products.Delete(entity);
            await _uow.SaveAsync();
        }
        // list of product search // TODO
        public async Task<ProductVM> GetBySearch(string searchItem)
        {
            // Get the requested Game entity from the repository
            var result = await _uow.Products.GetBySearch(searchItem);

            // Create the GameVM we want to return to the client
            var model = new ProductVM(result);

            // Return a 200 response with the GameVM
            return model;
        }
    }
}

	




    

