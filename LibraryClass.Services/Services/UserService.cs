using System;
using LibraryClass.Models.Entities;
using LibraryClass.Models.ViewModels.User;
using LibraryClass.Repositories.Repositories;

namespace LibraryClass.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uow;

        public UserService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<UserVM> Create(UserAddVM src)
        {
            // Create the new user entity
            var newEntity = new User(src);

            // Have the repository create the new user
            _uow.Users.Create(newEntity);
            await _uow.SaveAsync();

            // Create the UserVM we want to return to the client
            var model = new UserVM(newEntity);

            // Return a UserVM
            return model;
        }

        public async Task<UserVM> GetById(string id)
        {
            // Get the requested User entity from the repository
            var result = await _uow.Users.GetById(id);

            // Create the UserVM we want to return to the client
            var model = new UserVM(result);

            // Return the UserVM
            return model;
        }

        public async Task<UserVM> Update(UserUpdateVM src)
        {
            // Get the existing entity
            var entity = await _uow.Users.GetById(src.Id);

            // Perform the update
            entity.FirstName = src.FirstName;
            entity.LastName = src.LastName;
            entity.Phone = src.Phone;

            // Have the repository update the user
            _uow.Users.Update(entity);
            await _uow.SaveAsync();

            // Create the UserVM we want to return to the client
            var model = new UserVM(entity);

            // Return a 200 response with the UserVM
            return model;
        }

        //api/user/contactus endpoint 
    }
}



