using API_uitleensysteem.Models;
using API_uitleensysteem.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_uitleensysteem.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepo _productsRepo;

        public ProductsController(IProductsRepo productsRepo)
        {
            _productsRepo = productsRepo;
        }

        [HttpGet]
        public async Task<IEnumerable<Products>> GetProducts()
        {
            return await _productsRepo.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Products>> GetProducts(int id)
        {
            return await _productsRepo.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Products>> PostBooks([FromBody] Products product)
        {
            var newProduct = await _productsRepo.Create(product);
            return CreatedAtAction(nameof(GetProducts), new { id = newProduct.Id }, newProduct);
        }

        [HttpPut]
        public async Task<ActionResult> PutProducts(int id, [FromBody] Products product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            await _productsRepo.Update(product);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var productToDelte = await _productsRepo.Get(id);
            if (productToDelte == null)
                return NotFound();

            await _productsRepo.Delete(productToDelte.Id);
            return NoContent();
        }
    }
}