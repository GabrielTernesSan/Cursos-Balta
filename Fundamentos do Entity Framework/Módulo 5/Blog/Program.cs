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
            var post = context.Posts.FirstOrDefault(x => x.Id == 1);
            var post2 = context.Posts.AsNoTracking();
        }
    }
}