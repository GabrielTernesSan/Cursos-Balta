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
            var posts = GetPosts(context, 0, 25);
            //var posts = GetPosts(context, 25, 25);
            //var posts = GetPosts(context, 50, 25);
            //var posts = GetPosts(context, 75, 25);

            Console.WriteLine("Teste");
        }

        public static List<Post> GetPosts(BlogDataContext context, int skip = 0, int take = 25)
        {
            var posts = context
                .Posts
                .AsNoTracking()
                .Skip(skip)
                .Take(take)
                .ToList();
            return posts;
        }
    }
}