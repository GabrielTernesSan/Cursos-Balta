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

            var posts = context.PostWithTagsCount.ToList();

            foreach (var post in posts)
            {
                Console.WriteLine($"{post.Name}, {post.Count}");
            }

            Console.WriteLine("Teste");
        }
    }
}