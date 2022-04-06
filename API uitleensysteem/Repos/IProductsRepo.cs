using API_uitleensysteem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
