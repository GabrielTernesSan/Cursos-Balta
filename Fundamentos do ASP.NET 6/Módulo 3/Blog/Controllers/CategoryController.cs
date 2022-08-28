using Blog.Data;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly BlogDataContext _context;

        public CategoryController([FromServices] BlogDataContext context)
        {
            _context = context;
        }

        [HttpGet("v1/categories")]
        public async Task<IActionResult> GetAsync()
        {
            var categories = await _context.Categories.ToListAsync();
            return Ok(categories);
        }

        [HttpGet("v1/categories/{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            try
            {
                var category = await _context
                    .Categories
                    .FirstOrDefaultAsync(x => x.Id == id);

                return Ok(category);
            }catch(Exception ex)
            {
                return NotFound($"Id não encontrado! \n {ex.Message}");
            }
        }

        [HttpPost("v1/categories")]
        public async Task<IActionResult> PostAsync([FromBody] Category model)
        {
            try
            {
                await _context.Categories.AddAsync(model);
                await _context.SaveChangesAsync();

                return Created($"v1/categories/{model.Id}", model);
            }
            catch (Exception ex)
            {
                return BadRequest($"Verifique os dados e tente novamente! \n {ex.Message}");
            }
        }

        [HttpPut("v1/categories/{id:int}")]
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] Category model)
        {
            try
            {
                var category = await _context
                    .Categories
                    .FirstOrDefaultAsync(x => x.Id == id);

                category.Name = model.Name;
                category.Slug = model.Slug;

                _context.Categories.Update(category);
                await _context.SaveChangesAsync();

                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest($"Verifique os dados e tente novamente! \n {ex.Message}");
            }
        }

        [HttpDelete("v1/categories/{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            try
            {
                var category = await _context
                    .Categories
                    .FirstOrDefaultAsync(x => x.Id == id);

                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();

                return Ok(category);
            }
            catch (Exception ex)
            {
                return NotFound($"Id não encontrado! \n {ex.Message}");
            }
        }

    }
}
