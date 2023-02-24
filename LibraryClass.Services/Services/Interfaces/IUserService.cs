using LibraryClass.Models.ViewModels.User;

namespace LibraryClass.Services.Services
{
 
    public interface IUserService
    {
        Task<UserVM> Create(UserAddVM src);     // Create a new User
        Task<UserVM> GetById(string id);        // Get a single existing user by Id
        Task<UserVM> Update(UserUpdateVM src);  // Update an existing user
    }
}






