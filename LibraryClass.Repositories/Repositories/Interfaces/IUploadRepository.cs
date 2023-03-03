using System;
using LibraryClass.Models.Entities;

namespace LibraryClass.Services.Services.Interfaces
{
    public interface IUploadRepository
    {
        void Create(Upload entity);         // Create a new upload
        void Delete(Upload entity);         // Delete an upload
    }
}

