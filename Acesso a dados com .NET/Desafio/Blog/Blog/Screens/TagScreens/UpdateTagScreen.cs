using Blog.Models;
using Blog.Repository;

namespace Blog.Screens.TagScreens
{
    public class UpdateTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizando tag");
            Console.WriteLine("--------------");
            Console.WriteLine("Id: ");
            var id = Console.ReadLine();

            Console.WriteLine();

            Console.WriteLine("Name: ");
            var name = Console.ReadLine();

            Console.WriteLine();

            Console.WriteLine("Slug: ");
            var slug = Console.ReadLine();



            Update(new Tag {Id = int.Parse(id), Name = name, Slug = slug });
            Console.ReadKey();
            MenuTagScreen.Load();
        }

        public static void Update(Tag tag)
        {
            try
            {
                var repository = new Repository<Tag>(Database.Connection);
                repository.Update(tag);
                Console.WriteLine("Tag atualizada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível realizar sua solicitação!");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
