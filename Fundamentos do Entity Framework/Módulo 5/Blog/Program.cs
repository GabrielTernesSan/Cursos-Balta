using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var context = new BlogDataContext();
            var posts = context.Posts
                .Include(x => x.Author)
                // Evitar ao máximo, pq ele faz um subselect
                    .ThenInclude(x => x.Roles) // Está dentro de User
                .Include(x => x.Category);

            foreach (var post in posts)
            {
                foreach(var tag in post.Tags)
                {

                }
            }

            Console.WriteLine("Teste");
        }
    }
}