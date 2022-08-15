
using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var context = new BlogDataContext())
            {
                //var tag = new Tag { Name = "Azure", Slug = "Azure Cloud" };
                // Criado em memória
                //context.Tags.Add(tag); 
                // Para ir para o banco de fato precisamos dar um SaveChanges()
                //context.SaveChanges();

                //var tag = context.Tags.FirstOrDefault(x => x.Id == 4);
                //tag.Name = "Git";
                //tag.Slug = "GitHub";

                //context.Update(tag);
                //context.SaveChanges();

                //var tag = context.Tags.FirstOrDefault(x => x.Id == 4);

                //context.Remove(tag);
                //context.SaveChanges();

                // var tags = context.Tags;
                // Não executa a Query
                // Só seria executada quando chamada no foreach

                //var tags = context
                //    .Tags
                //    // Desabilita o Tracking para a sua consulta
                //    // ou seja, não salva as entidades retornadas em cache
                //    .AsNoTracking()
                //    .ToList();

                //foreach (var tag in tags)
                //{
                //    Console.WriteLine($"{tag.Name} - {tag.Slug}");
                //}

                // DELETE E UPDATE SEMPRE SEM AsNoTracking

                //var tag = context
                //    .Tags
                //    .AsNoTracking() // Remover
                //    .FirstOrDefault(x => x.Id == 1);

                //tag.Name = "Git";
                //tag.Slug = "GitHub";

                var tag = context
                    .Tags
                    .AsNoTracking()
                    // Executa a Query também
                    //.FirstOrDefault(x => x.Id == 1); pega o primeiro mesmo com Ids repetidos
                    .SingleOrDefault(x => x.Id == 1); // se tiver mais de um com o mesmo Id dá erro

                Console.WriteLine(tag?.Name); // ? se vier nulo não vai dar erro
            }
        }
    }
}