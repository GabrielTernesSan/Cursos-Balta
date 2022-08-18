using Blog.Data;
using Blog.Models;

namespace Blog
{
    class Program
    {
        static void Main(string[] args)
        {
            // Vai dar erro, porque foi introduzido campo 'GitHub' e no banco não
            using var context = new BlogDataContext();

            context.Users.Add(new User()
            {
                Bio = "9x Microsoft MVP",
                GitHub = "GabrielTernesSan",
                Email = "andre@balta.io",
                Image = "https://balta.io",
                Name = "André Baltieri",
                PasswordHash = "hash",
                Slug = "andre-baltieri"
            });
            context.SaveChanges();
            // para atualizar, cria uma nova migration
            // update-database depois
        }
    }
}