using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Lazy load (Carregamento preguiçoso)
            using var context = new BlogDataContext();

            var posts = context.Posts;
            // Por padrão as Tags não são carregadas
            foreach (var post in posts)
            {
                // Com o Lazy load, somente quando eu chamar as tags elas irão ser chamadas
                foreach(var tag in post.Tags)
                {

                }
            }

            Console.WriteLine("Teste");

            // Eager Load
            using var context2 = new BlogDataContext();

            // Não chama as tags por padrão
            //var posts2 = context2.Posts;

            // Para incluir as tags
            var posts2 = context2.Posts.Include(x => x.Tags); // INNER JOIN
            foreach (var post in posts)
            {
                // Quando carregarmos as tags ela será nula
                foreach (var tag in post.Tags)
                {
                    //Null
                }
            }

            Console.WriteLine("Teste");
        }
    }
}