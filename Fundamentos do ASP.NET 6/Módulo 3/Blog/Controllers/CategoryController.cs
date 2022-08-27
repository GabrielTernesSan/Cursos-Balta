using Blog.Data;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet("v1/categories")]
        public IActionResult Get(BlogDataContext context)
        {
            var categories = context.Categories.ToList();
            return Ok(categories);
        }

        [HttpGet("v2/categories")]
        public IActionResult Get2(BlogDataContext context)
        {
            var categories = context.Categories.ToList();
            return Ok(categories);
        }
    }
}
