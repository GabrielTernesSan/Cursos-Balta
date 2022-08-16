
using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog
{
    class Program
    {
        static void Main(string[] args)
        {
            using var context = new BlogDataContext();

            var post = context
                .Posts
                //.AsNoTracking() // PRECISA DO TRACKING
                .Include(x => x.Author)
                .Include(x => x.Category)
                .OrderByDescending(x => x.LastUpdateDate)
                .FirstOrDefault();

            post.Author.Name = "Teste"; // Mudou no banco

            context.Update(post);
            context.SaveChanges();
        }
    }
}