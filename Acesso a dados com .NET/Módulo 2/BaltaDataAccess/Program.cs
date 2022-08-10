using System;
using BaltaDataAccess.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BaltaDataAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            const string connectionString 
                = "Server=localhost,1433;Database=balta;User ID=sa;Password=G@abriel613390;TrustServerCertificate=True;";

            using (var connection = new SqlConnection(connectionString))
            {
                ListCategories(connection);
                // CreateCategory(connection);
                UpdateCategory(connection);
                ListCategories(connection);
            }
        }
        static void ListCategories(SqlConnection connection)
        {
            var categories = connection.Query<Category>("SELECT [Id], [Title] FROM [Category] ORDER BY [Title]");
            foreach (var category in categories)
            {
                Console.WriteLine($"{category.Id} - {category.Title}");
            }
        }
        static void CreateCategory(SqlConnection connection)
        {
            var categoria = new Category();
            categoria.Id = Guid.NewGuid();
            categoria.Title = "Amazon AWS";
            categoria.Url = "amazon";
            categoria.Summary = "AWS Cloud";
            categoria.Order = 8;
            categoria.Description = "Categoria destinada a serviços do AWS";
            categoria.Featured = false;

            // SQL Injection
            // Para evitar esse tipo de ataque,
            // NUNCA usar a concatenação de strings ($)

            // Usaremos Parâmetros
            var insertSql
                = @"INSERT INTO 
                    [Category]
                        VALUES(
                                @Id,
                                @Title,
                                @Url,
                                @Summary,
                                @Order,
                                @Description,
                                @Featured)";

            // Retorna o número de linhas afetadas
            var rows = connection.Execute(insertSql, new
            {
                categoria.Id,
                categoria.Title,
                categoria.Url,
                categoria.Summary,
                categoria.Order,
                categoria.Description,
                categoria.Featured
            });

            Console.WriteLine($"{rows} - linhas inseridas");
        }
        static void UpdateCategory(SqlConnection connection)
        {
            var updateQuery = "UPDATE [Category] SET [Title]=@Title WHERE [Id]=@Id";

            var rows = connection.Execute(updateQuery, new
            {
                // Também funciona
                // Id = "AF3407AA-11AE-4621-A2EF-2028B85507C4",
                Id = new Guid("AF3407AA-11AE-4621-A2EF-2028B85507C4"),
                Title = "Frontend 2021"
            });

            Console.WriteLine($"{rows} - Registros atualizados;");
        }
    }
}