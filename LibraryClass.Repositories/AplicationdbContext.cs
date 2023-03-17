using LibraryClass.Models.Entities;
using LibraryClass.Models.ViewModels.Notifications;
//using LibraryClass.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryClass.Repositories
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products => Set<Product>();//not sure if the entityEndpoint in entities

        public DbSet<User> Users => Set<User>();
        public DbSet<Upload> Uploads=> Set<Upload>();

        public DbSet<Notification> Notifications => Set<Notification>();
    }
}