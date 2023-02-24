using LibraryClass.Repositories;
using LibraryClass.Repositories.Repositories;
using LibraryClass.Repositories.Repositories.Interfaces;
using LibraryClass.Models.Entities;


namespace LibraryClass.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable  //error
    {
        private readonly ApplicationDbContext _context;

        private IProductRepository? _products { get; set; } //interface 
        private IUserRepository? _users { get; set; }  


        public IProductRepository Products //mayuscula
        {
            get  //this what does is that creates a repository just the first time the function is called 
            {
                if (_products == null) //from market for you repos
                    _products = new ProductRepository(_context);
                return _products;
            }
            private set
            {
                _products = value;
            }
        }
        public IUserRepository Users
        {
            get
            {
                if (_users == null)
                    _users = new UserRepository(_context);
                return _users;
            }
            private set
            {
                _users = value;
            }
        }
    

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
