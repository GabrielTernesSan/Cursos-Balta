
using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog
{
    class Program
    {

        private const string CONNECTION_STRING = "Server=localhost,1433;Database=Blog;User ID=sa;Password=G@abriel613390;TrustServerCertificate=True;";

        static void Main(string[] args)
        {
            // ReadUsers();
            // ReadUser(); 
            // CreateUser();
            // UpdateUser();
            DeleteUser();
        }
        public static void ReadUsers()
        {
            using(var connection = new SqlConnection(CONNECTION_STRING))
            {
                /* 
                 * O Dapper.Contrib pluraliza as classes, entao ele 
                 * procurou a tabela "Users" e deu erro. Para corrigir isso
                 * adicionamos uma annotation na classe [Table] da Dapper.Contrib.Extensions
                 * e não da System.ComponentModel.DataAnnotations.Schema.
                 */
                var users = connection.GetAll<User>();

                foreach(var user in users)
                {
                    Console.WriteLine(user.Name);
                }
            }
        }

        public static void ReadUser()
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var user = connection.Get<User>(1);

                Console.WriteLine(user.Name);
            }
        }

        public static void CreateUser()
        {
            var user = new User()
            {
                Bio = "Equipe balta.io",
                Email = "hello@balta.io",
                Image = "https://",
                Name = "Equipe balta.io",
                PasswordHash = "HASH",
                Slug = "equipe-balta"
            };
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                // Retorna um long
                connection.Insert<User>(user);

                Console.WriteLine("Cadastro realizado com sucesso");
            }
        }

        public static void UpdateUser()
        {
            var user = new User()
            {
                Id = 2,
                Bio = "Equipe | balta.io",
                Email = "hello@balta.io",
                Image = "https://",
                Name = "Equipe de suporte balta.io",
                PasswordHash = "HASH",
                Slug = "equipe-balta"
            };
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                // Retorna um long
                connection.Update<User>(user);

                Console.WriteLine("Atualização realizada com sucesso");
            }
        }

        public static void DeleteUser()
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var user = connection.Get<User>(2);
                // Retorna um long
                connection.Delete<User>(user);

                Console.WriteLine("Exlusão realizada com sucesso");
            }
        }

    }
}