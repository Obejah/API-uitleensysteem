using API_uitleensysteem.Models;


namespace API_uitleensysteem.Repos
{
    public interface IProductsRepo
    {
        Task<IEnumerable<Products>> Get();
        Task<Products> Get(int id);
        Task<Products> Create(Products products);
        Task Update(Products products);
        Task Delete(int id);
    }
}
