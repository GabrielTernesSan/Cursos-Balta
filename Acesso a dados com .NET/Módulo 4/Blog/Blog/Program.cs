
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
            ReadUsers();   
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
    }
}