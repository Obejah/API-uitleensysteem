using API_uitleensysteem.Models;

namespace API_uitleensysteem.Repos
{
    public interface ICategoryRepo
    {
        Task<IEnumerable<Category>> Get();
        Task<Category> Get(int id);
        Task Delete(int id);
        Task Update(Category category);
        Task<Category> Create(Category category);
    }
}
