using API_uitleensysteem.Repos;
using Microsoft.EntityFrameworkCore;

namespace API_uitleensysteem.Models
{
    public class ProductsContext : DbContext
    {
        public ProductsContext(DbContextOptions<ProductsContext> options)
            : base(options)
        {
            Database.EnsureCreated();       
        }
        public DbSet<Products> Products { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
