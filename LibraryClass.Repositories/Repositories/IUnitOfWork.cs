using System;
using System.Collections.Generic;

using LibraryClass.Repositories.Repositories.Interfaces;
using LibraryClass.Services.Services.Interfaces;

namespace LibraryClass.Repositories.Repositories
{

    public interface IUnitOfWork
    {
        // Repositories
        IProductRepository Products { get; }  //from entity class
       // object Markets { get; }

        IUserRepository Users { get; }  // users

        IUploadRepository Uploads { get; }  //upload 


        // Save Method
        Task SaveAsync();
    }
}
