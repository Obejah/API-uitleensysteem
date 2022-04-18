using API_uitleensysteem.Models;
using Microsoft.EntityFrameworkCore;

namespace API_uitleensysteem.Repos
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly ProductsContext _context;
        public CategoryRepo(ProductsContext context)
        {
            _context = context;
        }
        public async Task<Category> Create(Category category)
        {
            _context.Category.Add(category);
            await _context.SaveChangesAsync();

            return category;
        }
      
        public async Task Delete(int id)
        {
            var categoryToDelete = await _context.Category.FindAsync(id);
            _context.Category.Remove(categoryToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> Get()
        {
            return await _context.Category.ToListAsync();
        }

        public async Task<Category> Get(int id)
        {
            return await _context.Category.FindAsync(id);
        }

        public async Task Update(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

       
    }
}