
using Blog.Models;
using Blog.Repository;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog
{
    class Program
    {

        private const string CONNECTION_STRING = "Server=localhost,1433;Database=Blog;User ID=sa;Password=G@abriel613390;TrustServerCertificate=True;";

        static void Main(string[] args)
        {
            var connection = new SqlConnection(CONNECTION_STRING);
            connection.Open();

             ReadUsers(connection);
            // ReadUser(connection); 
            // CreateUser(connection);
            // UpdateUser(connection);
            // DeleteUser(connection);
            connection.Close();
        }
        public static void ReadUsers(SqlConnection connection)
        {
            var repository = new UserRepository(connection);
            var users = repository.Get();

            foreach(var user in users)
                Console.WriteLine(user.Name);
        }

        public static void ReadUser(SqlConnection connection)
        {
            var repository = new UserRepository(connection);
            var user = repository.GetById(1);
            Console.WriteLine(user.Name);
        }

        public static void CreateUser(SqlConnection connection)
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
            var repository = new UserRepository(connection);
            repository.Create(user);
            Console.WriteLine("Usuário criado com sucesso");
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