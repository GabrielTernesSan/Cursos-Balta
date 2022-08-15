
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

                
                var tags1 = context // Chegaria no contexto
                    .Tags         // Chegaria nas tags
                    .ToList()    // Executaria um SELECT em todas as tags
                    .Where(x => x.Name.Contains(".NET")); // E filtraria isso em memória

                var tags2 = context // Chegaria no contexto
                    .Tags         // Chegaria nas tags
                    .Where(x => x.Name.Contains(".NET")) // Filtra primeiro
                    .ToList(); // ToList() sempre por último

                // O ToList() força a execução da Query
                //var tags = context.Tags.ToList();

                foreach (var tag in tags)
                {
                    Console.WriteLine($"{tag.Name} - {tag.Slug}");
                }
            }
        }
    }
}