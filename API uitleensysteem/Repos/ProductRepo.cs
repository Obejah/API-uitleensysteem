using API_uitleensysteem.Models;
using Microsoft.EntityFrameworkCore;

namespace API_uitleensysteem.Repos
{
    public class ProductRepo : IProductsRepo
    {
        private readonly ProductsContext _context;
        public ProductRepo(ProductRepo context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Products>> Get()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Products> Get(int id)
        {
            return await _context.Products.FindAsync(id);
        }
        public async Task<Products> Create(Products products)
        {
            _context.Products.Add(products);
            await _context.SaveChangesAsync();

            return products;
        }
        public async Task Update(Products products)
        {
            _context.Entry(products).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var productToDelete = await _context.Products.FindAsync(id);
            _context.Products.Remove(productToDelete);
            await _context.SaveChangesAsync();
        }
        Task IProductsRepo.Update(Products products)
        {
            throw new NotImplementedException();
        }

        Task IProductsRepo.Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
