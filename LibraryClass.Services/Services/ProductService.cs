using System;
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

        public async Task<ProjectVM> Create(ProjectAddVM src, string userId)
        {
            // Create the new Game entity
            var newEntity = new Product(src, userId);

            // Have the repository create the new game
            _uow.Products.Create(newEntity);
            await _uow.SaveAsync();

            // Create the GameVM we want to return to the client
            var model = new ProjectVM(newEntity);

            // Return a GameVM
            return model;
        }

        public async Task<List<ProjectVM>> GetAll()
        {
            // Get the Game entities from the repository
            var results = await _uow.Products.GetAll();

            // Build the GameVM view models to return to the client
            var models = results.Select(product => new ProjectVM(product)).ToList();

            // Return the GameVMs
            return models;
        }

        public async Task<ProjectVM> GetById(Guid id)
        {
            // Get the requested Game entity from the repository
            var result = await _uow.Products.GetById(id);

            // Create the GameVM we want to return to the client
            var model = new ProjectVM(result);

            // Return a 200 response with the GameVM
            return model;
        }

        public async Task<ProjectVM> Update(ProjectUpdateVM src)
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
            var model = new ProjectVM(entity);

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
    }
}

	




    

