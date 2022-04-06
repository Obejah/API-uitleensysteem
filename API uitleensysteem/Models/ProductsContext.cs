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
        // TODO: database anamaken in SQL Server MANAGEMENT STUDIO 
        public DbSet<Products> Products { get; set; }
        // TODO: Verwijder onderstaande code en zorg dat het functioneerd met alleen de bovenstaande code
        public static implicit operator ProductsContext(ProductRepo v)
        {
            throw new NotImplementedException();
        }
    }
}
