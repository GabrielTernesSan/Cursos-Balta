using Blog.Data;
using Blog.Models;
using Blog.ViewModels;
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
        public async Task<IActionResult> PostAsync([FromBody] EditorCategoryViewModel model)
        {
            // Valida
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var category = new Category
                {
                    Id = 0,
                    Posts = null,
                    Name = model.Name,
                    Slug = model.Slug
                };

                await _context.Categories.AddAsync(category);
                await _context.SaveChangesAsync();

                return Created($"v1/categories/{category.Id}", category);
            }
            catch (DbUpdateException e)
            {
                return StatusCode(500, $"05XE9 - Não foi possível incluir a categoria \n {e.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"05X10 - Erro interno no servidor \n {ex.Message}");
            }
        }

        [HttpPut("v1/categories/{id:int}")]
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] EditorCategoryViewModel model)
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
            catch (DbUpdateException e)
            {
                return StatusCode(500, $"05XE8 - Não foi possível alterar a categoria \n {e.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"05X11 - Erro interno no servidor \n {ex.Message}");
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
            catch (DbUpdateException e)
            {
                return StatusCode(500, $"05XE7 - Não foi possível excluir a categoria \n {e.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"05X12 - Erro interno no servidor \n {ex.Message}");
            }
        }

    }
}
