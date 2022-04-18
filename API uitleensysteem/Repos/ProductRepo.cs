using API_uitleensysteem.Models;
using Microsoft.EntityFrameworkCore;

namespace API_uitleensysteem.Repos
{
    public class ProductRepo : IProductsRepo
    {
        private readonly ProductsContext _context;

        public ProductRepo(ProductsContext context)
        {
            _context = context;
        }

        public async Task<Products> Create(Products product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task Delete(int id)
        {
            var productToDelte = await _context.Products.FindAsync(id);
            _context.Products.Remove(productToDelte);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Products>> Get()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Products> Get(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task Update(Products product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
