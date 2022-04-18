using API_uitleensysteem.Models;
using API_uitleensysteem.Repos;
using Microsoft.AspNetCore.Mvc;


namespace API_uitleensysteem.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepo _categoryRepository;

        public CategoryController(ICategoryRepo categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Category>> GetCategory()
        {
            return await _categoryRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            return await _categoryRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory([FromBody] Category categorie)
        {
            var newCategory = await _categoryRepository.Create(categorie);
            return CreatedAtAction(nameof(GetCategory), new { id = newCategory.ID }, newCategory);
        }

        [HttpPut]
        public async Task<ActionResult> PutCategory(int id, [FromBody] Category category)
        {
            if (id != category.ID)
            {
                return BadRequest();
            }

            await _categoryRepository.Update(category);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var categoryToDelete = await _categoryRepository.Get(id);
            if (categoryToDelete == null)
                return NotFound();

            await _categoryRepository.Delete(categoryToDelete.ID);
            return NoContent();
        }
    }
}
