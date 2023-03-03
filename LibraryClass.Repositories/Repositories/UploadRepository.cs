using System;
using LibraryClass.Models.Entities;
using LibraryClass.Services.Services.Interfaces;

namespace LibraryClass.Repositories.Repositories
{
    public class UploadRepository : IUploadRepository
    {
        private readonly ApplicationDbContext _context;

        public UploadRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(Upload entity)
        {
            // Perform the add in memory
            _context.Add(entity);
        }

        // Delete a upload
        public void Delete(Upload entity)
        {
            // Delete the entity
            _context.Remove(entity);
        }
    }
}
