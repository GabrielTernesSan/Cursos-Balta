using System;
using System.Data;
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
                // ListCategories(connection);
                // GetCategory(connection);
                // ExecuteProcedure(connection);
                // ExecuteReadProcedure(connection);
                // ExecuteScalar(connection);
                // ReadView(connection);
                // OneToOne(connection);
                // OneToMany(connection);
                // QueryMultiple(connection);
                // SelectIn(connection);
                // Like(connection, "api");
                Transaction(connection);

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

        static void ExecuteProcedure(SqlConnection connection)
        {
            var procedure = "[spDeleteStudent]";

            var parameters = new
            {
                StudentId = "9ea8e017-3a5e-4b5e-a4f6-9c2739362c9c"
            };

            var rows = connection.Execute(
                procedure, 
                parameters, 
                commandType: CommandType.StoredProcedure);

            Console.WriteLine($"{rows} - linhas afetadas");
        }

        static void ExecuteReadProcedure(SqlConnection connection)
        {
            var procedure = "[spGetCoursesByCategory]";

            var parameters = new
            {
                CategoryId = "09ce0b7b-cfca-497b-92c0-3290ad9d5142"
            };

            // Retorna um array de cursos do tipo 'dynamic'
            var courses = connection.Query(
                procedure,
                parameters,
                commandType: CommandType.StoredProcedure);
            // Então nós podemos fazer um foreach
            foreach(var course in courses)
            {
                // Por ser um 'dynamic' não temos acesso as propriedades
                Console.WriteLine(course.Id);
            }
        }

        static void ExecuteScalar(SqlConnection connection)
        {
            var categoria = new Category();
            categoria.Title = "Kafka";
            categoria.Url = "kafka";
            categoria.Summary = "Kafka";
            categoria.Order = 11;
            categoria.Description = "Categoria destinada a serviços do Kafka";
            categoria.Featured = true;

            var insertSql
                = @"
                    INSERT INTO 
                        [Category]
                    OUTPUT inserted.[Id]
                            VALUES(
                                    NEWID(),
                                    @Title,
                                    @Url,
                                    @Summary,
                                    @Order,
                                    @Description,
                                    @Featured)";
            // O 'ExecuteScalar' serve para retornar valores especificos de uma procedure
            var id = connection.ExecuteScalar<Guid>(insertSql, new
            {
                categoria.Title,
                categoria.Url,
                categoria.Summary,
                categoria.Order,
                categoria.Description,
                categoria.Featured
            });

            Console.WriteLine($"A categoria inserida foi :{id}");
        }

        static void ReadView(SqlConnection connection)
        {
            var sql = "SELECT * FROM [vwCourses]";

            var courses = connection.Query(sql);
            foreach(var course in courses)
            {
                Console.WriteLine($"{course.Id} - {course.Title}");
            }
        }

        static void OneToOne(SqlConnection connection)
        {
            var sql = @"
                    SELECT 
                        * 
                    FROM 
                        [CareerItem] 
                        INNER JOIN [Course] 
                        ON [CareerItem].[CourseId] = [Course].[Id]";

            var items = connection.Query<CareerItem, Course, CareerItem>(
                sql,
                (careerItem, course) =>{
                    careerItem.Course = course;
                    return careerItem;
                }, splitOn: "Id");

            foreach (var item in items)
            {
                //Console.WriteLine(item.Course.Title);
                Console.WriteLine($"{item.Title} - Curso: {item.Course.Title}");
            }
        }

        static void OneToMany(SqlConnection connection)
        {
            var sql = @"
                SELECT 
                    [Career].[Id],
                    [Career].[Title],
                    [CareerItem].[CareerId],
                    [CareerItem].[Title]
                FROM 
                    [Career] 
                INNER JOIN 
                    [CareerItem] ON [CareerItem].[CareerId] = [Career].[Id]
                ORDER BY 
                    [Career].[Title]";

            var careers = new List<Career>();

            var items = connection.Query<Career, CareerItem, Career>(
               sql,
               (career, item) => {
                   var car = careers.Where(x => x.Id == career.Id).FirstOrDefault();
                   if(car == null)
                   {
                       car = career;
                       car.Items.Add(item);
                       careers.Add(car);
                   }
                   else
                   {
                       car.Items.Add(item);
                   }

                   return career;
               }, splitOn: "CareerId");

            foreach (var career in careers)
            {
                Console.WriteLine($"{career.Title}");
                foreach (var item in career.Items)
                {
                    Console.WriteLine($" - {item.Title}");
                }
            }
        }

        static void QueryMultiple(SqlConnection connection)
        {
            var query = "SELECT * FROM [Category]; SELECT * FROM [Course]";

            using(var multi = connection.QueryMultiple(query))
            {
                var categories = multi.Read<Category>();
                var courses = multi.Read<Course>();

                foreach(var item in categories)
                {
                    Console.WriteLine(item.Title);
                }

                foreach (var item in courses)
                {
                    Console.WriteLine(item.Title);
                }
            }
        }

        static void SelectIn(SqlConnection connection)
        {
            var query = @"
                SELECT 
                    * 
                FROM 
                    [Career]
                WHERE 
                    [Id] 
                IN @Id
                    -- ('01ae8a85-b4e8-4194-a0f1-1c6190af54cb',
                    --'e6730d1c-6870-4df3-ae68-438624e04c72')
                    ";

            var items = connection.Query<Career>(query, new
            {
                Id = new[]
                {
                    "01ae8a85-b4e8-4194-a0f1-1c6190af54cb",
                    "e6730d1c-6870-4df3-ae68-438624e04c72"
                }
            });

            foreach(var item in items)
            {
                Console.WriteLine(item.Title);
            }
        }

        static void Like(SqlConnection connection, string term)
        {
            var query = @"
                SELECT 
                    * 
                FROM 
                    [Course]
                WHERE 
                    [Title] 
                LIKE
                    @exp";

            var items = connection.Query<Course>(query, new
            {
                exp = $"%{term}%"
            });

            foreach (var item in items)
            {
                Console.WriteLine(item.Title);
            }
        }

        static void Transaction(SqlConnection connection)
        {
            var categoria = new Category();
            categoria.Id = Guid.NewGuid();
            categoria.Title = "Minha categoria que não quero";
            categoria.Url = "Não salva";
            categoria.Summary = "não";
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

            connection.Open();
           using(var transaction = connection.BeginTransaction())
            {
                var rows = connection.Execute(insertSql, new
                {
                    categoria.Id,
                    categoria.Title,
                    categoria.Url,
                    categoria.Summary,
                    categoria.Order,
                    categoria.Description,
                    categoria.Featured
                }, transaction);
                
                //transaction.Commit();

                // Desfaz as alterações
                transaction.Rollback();
            
                Console.WriteLine($"{rows} - linhas inseridas");
            }

        }
    }
}