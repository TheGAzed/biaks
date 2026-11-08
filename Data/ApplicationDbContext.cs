using biaks.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace biaks.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
		public DbSet<Product> Products { get; set; }
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
