using API_uitleensysteem.Models;
using API_uitleensysteem.Repos;
using Microsoft.AspNetCore.Mvc;

namespace API_uitleensysteem.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepo _productRepository;

        public ProductsController(IProductsRepo productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Products>> GetProducts()
        {
            return await _productRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Products>> GetProducts(int id)
        {
            return await _productRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Products>> PostProducts([FromBody] Products product)
        {
            var newProduct = await _productRepository.Create(product);
            return CreatedAtAction(nameof(GetProducts), new { id = newProduct.ID }, newProduct);
        }

        [HttpPut]
        public async Task<ActionResult> PutProducts(int id, [FromBody] Products product)
        {
            if (id != product.ID)
            {
                return BadRequest();
            }

            await _productRepository.Update(product);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var productToDelte = await _productRepository.Get(id);
            if (productToDelte == null)
                return NotFound();

            await _productRepository.Delete(productToDelte.ID);
            return NoContent();
        }
    }
}