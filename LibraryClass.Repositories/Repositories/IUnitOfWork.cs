using System;
using System.Collections.Generic;

using LibraryClass.Repositories.Repositories.Interfaces;

namespace LibraryClass.Repositories.Repositories
{

    public interface IUnitOfWork
    {
        // Repositories
        IProductRepository Products { get; }  //from entity class
       // object Markets { get; }

        IUserRepository Users { get; }  // users 

        // Save Method
        Task SaveAsync();
    }
}
