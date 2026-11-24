using Microsoft.EntityFrameworkCore;
using Duyan.Models;

namespace Duyan.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
    }
}