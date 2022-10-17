using Blog.Data;
using Blog.Extensions;
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
            try
            {
                var categories = await _context.Categories.ToListAsync();
                return Ok(new ResultViewModel<List<Category>>(categories));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<List<Category>>($"05X04 - Erro interno no servidor "));
            }
        }

        [HttpGet("v1/categories/{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            try
            {
                var category = await _context
                    .Categories
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (category == null)
                    return NotFound(new ResultViewModel<Category>("Conteúdo não encontrado!"));

                return Ok(new ResultViewModel<Category>(category));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Category>($"05X05 - Erro interno no servidor "));
            }
        }

        [HttpPost("v1/categories")]
        public async Task<IActionResult> PostAsync([FromBody] EditorCategoryViewModel model)
        {
            // Valida
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<Category>(ModelState.GetErrors()));

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

                return Created($"v1/categories/{category.Id}", new ResultViewModel<Category>(category));
            }
            catch (DbUpdateException e)
            {
                return StatusCode(500, new ResultViewModel<Category>($"05XE9 - Não foi possível incluir a categoria \n {e.Message}"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultViewModel<Category>($"05X10 - Erro interno no servidor \n {ex.Message}"));
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

                if (category == null)
                    return NotFound(new ResultViewModel<Category>("Conteúdo não encontrado!"));

                category.Name = model.Name;
                category.Slug = model.Slug;

                _context.Categories.Update(category);
                await _context.SaveChangesAsync();

                return Ok(new ResultViewModel<Category>(category));
            }
            catch (DbUpdateException e)
            {
                return StatusCode(500, new ResultViewModel<Category>($"05XE8 - Não foi possível alterar a categoria \n {e.Message}"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultViewModel<Category>($"05X11 - Erro interno no servidor \n {ex.Message}"));
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

                if (category == null)
                    return NotFound(new ResultViewModel<Category>("Conteúdo não encontrado!"));

                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();

                return Ok(new ResultViewModel<Category>(category));
            }
            catch (DbUpdateException e)
            {
                return StatusCode(500, new ResultViewModel<Category>($"05XE7 - Não foi possível excluir a categoria \n {e.Message}"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultViewModel<Category>($"05X12 - Erro interno no servidor \n {ex.Message}"));
            }
        }

    }
}
