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

            using (var connection = new SqlConnection(connectionString))
            {
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

                var categories = connection.Query<Category>("SELECT [Id], [Title] FROM [Category] ORDER BY [Title]");
                foreach (var category in categories)
                {
                    Console.WriteLine($"{category.Id} - {category.Title}");
                }
            }
        }
    }
}