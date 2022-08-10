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
                // CreateCategory(connection);
                // CreateManyCategory(connection);
                // UpdateCategory(connection);
                // DeleteCategory(connection);
                ListCategories(connection);
                // GetCategory(connection);
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
        static void GetCategory(SqlConnection connection)
        {
            var category = connection
                .QueryFirstOrDefault<Category>(
                    "SELECT TOP 1 [Id], [Title] FROM [Category] WHERE [Id] = @Id",
                    new
                    {
                        Id = "af3407aa-11ae-4621-a2ef-2028b85507c4"
                    }
                );

            Console.WriteLine($"{category.Id} - {category.Title}");
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
                Id = new Guid("AF3407AA-11AE-4621-A2EF-2028B85507C4"),
                Title = "Frontend 2021"
            });

            Console.WriteLine($"{rows} - Registros atualizados;");
        }
        static void DeleteCategory(SqlConnection connection)
        {
            var deleteCategory = "DELETE [Category] WHERE [Id] = @Id";
            var rows = connection.Execute(deleteCategory, new
            {
                Id = new Guid("07248d68-026a-4490-887f-680a928b13b8")
            });

            Console.WriteLine($"{rows} registros excluídos");
        }

        static void CreateManyCategory(SqlConnection connection)
        {
            var categoria = new Category();
            categoria.Id = Guid.NewGuid();
            categoria.Title = "Amazon AWS";
            categoria.Url = "amazon";
            categoria.Summary = "AWS Cloud";
            categoria.Order = 8;
            categoria.Description = "Categoria destinada a serviços do AWS";
            categoria.Featured = false;

            var categoria2 = new Category();
            categoria2.Id = Guid.NewGuid();
            categoria2.Title = "Categoria Nova";
            categoria2.Url = "categoria-nova";
            categoria2.Summary = "Categoria Nova";
            categoria2.Order = 9;
            categoria2.Description = "Categoria";
            categoria2.Featured = true;

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

            var rows = connection.Execute(insertSql, new[]
            {
                new
                {
                    categoria.Id,
                    categoria.Title,
                    categoria.Url,
                    categoria.Summary,
                    categoria.Order,
                    categoria.Description,
                    categoria.Featured
                },
                new
                {
                    categoria2.Id,
                    categoria2.Title,
                    categoria2.Url,
                    categoria2.Summary,
                    categoria2.Order,
                    categoria2.Description,
                    categoria2.Featured
                }
            });

            Console.WriteLine($"{rows} - linhas inseridas");
        }
    }
}