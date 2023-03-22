using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryClass.Models.Entities;
using LibraryClass.Models.ViewModels;

namespace LibraryClass.Services.Services.Interfaces

    {
        public interface IProductService

    {//from view models
            Task<ProductVM> Create(ProductAddVM src, string userId);     // Create a new game // relation with user
            Task<ProductVM> GetById(Guid id);          // Get a single existing game by Id
            Task<List<ProductVM>> GetAll();            // Get all of the games
            Task<ProductVM> Update(ProductUpdateVM src);  // Update an existing game
            Task Delete(Guid id);                   // Delete a game
            Task<List<ProductVM>> GetBySearch();//(string searchItem);  //THIS IS DONE?
            
        }
    }
