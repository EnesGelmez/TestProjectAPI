using Microsoft.EntityFrameworkCore;
using TestProjectAPI.Models;

namespace TestProjectAPI.Data
{
    public class UsersDbContext : DbContext
    {
        public UsersDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }

        public DbSet<Worker> Workers { get; set; }

    }
}
