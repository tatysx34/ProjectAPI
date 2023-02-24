using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryClass.Models.ViewModels;

namespace LibraryClass.Services.Services.Interfaces

    {
        public interface IProductService

    {//from view models
            Task<ProjectVM> Create(ProjectAddVM src, string userId);     // Create a new game // relation with user
            Task<ProjectVM> GetById(Guid id);          // Get a single existing game by Id
            Task<List<ProjectVM>> GetAll();            // Get all of the games
            Task<ProjectVM> Update(ProjectUpdateVM src);  // Update an existing game
            Task Delete(Guid id);                   // Delete a game
        }
    }
