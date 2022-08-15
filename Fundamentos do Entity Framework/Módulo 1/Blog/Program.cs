
using Blog.Data;
using Blog.Models;

namespace Blog
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var context = new BlogDataContext())
            {
                var tag = new Tag { Name = "Azure", Slug = "Azure Cloud" };
                // Criado em memória
                context.Tags.Add(tag); 
                // Para ir para o banco de fato precisamos dar um SaveChanges()
                context.SaveChanges();
            }
        }
    }
}