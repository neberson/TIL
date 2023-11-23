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
            const string connectionString = "Server=localhost,1433;Database=balta;User ID=SA;Password=1q2w3e4r@#$;TrustServerCertificate=True";


            using (var connection = new SqlConnection(connectionString))
            {
                //ListCategories(connection);
                //CreateCategory(connection);
                //UpdateCategory(connection);
                //CreateManyCategory(connection);
                //DeleteCategory(connection);
                //ExecuteProcedure(connection);
                ExecuteReadProcedure(connection);

            }
            Console.WriteLine("Hello World!");
        }

        static void ListCategories(SqlConnection connection)
        {
            var categories = connection.Query<Category>("SELECT Id, Title FROM Category");
            foreach (var item in categories)
            {
                Console.WriteLine($"{item.Id} - {item.Title}");
            }
        }
        static void CreateCategory(SqlConnection connection)
        {
            var category = new Category();

            category.Id = Guid.NewGuid();
            category.Title = "Amazon AWS";
            category.Url = "amazon";
            category.Description = "Categoria destinada a serviços do AWS";
            category.Order = 8;
            category.Summary = "AWS Cloud";
            category.Featured = false;

            var insertSql = @"INSERT INTO 
                                    Category 
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
                category.Id,
                category.Title,
                category.Url,
                category.Summary,
                category.Order,
                category.Description,
                category.Featured
            });

            Console.WriteLine($"{rows} linhas inseridas");
        }
        static void UpdateCategory(SqlConnection connection)
        {
            var updateCategory = "UPDATE Category SET Title=@title WHERE Id=@id";
            var rows = connection.Execute(updateCategory, new
            {
                id = new Guid("bb69989d-91c5-4f59-8488-5e640d943f5c"),
                title = "Frontend 2021"
            });
            Console.WriteLine($"{rows} registros atualizados");
        }

        static void DeleteCategory(SqlConnection connection)
        {
            var deleteCategory = "DELETE FROM Category WHERE Id=@id";
            var rows = connection.Execute(deleteCategory, new
            {
                id = new Guid("bb69989d-91c5-4f59-8488-5e640d943f5c"),
                title = "Frontend 2021"
            });
            Console.WriteLine($"{rows} registros deletados");
        }

        static void CreateManyCategory(SqlConnection connection)
        {
            var category = new Category();

            category.Id = Guid.NewGuid();
            category.Title = "Amazon AWS";
            category.Url = "amazon";
            category.Description = "Categoria destinada a serviços do AWS";
            category.Order = 8;
            category.Summary = "AWS Cloud";
            category.Featured = false;

            var category2 = new Category();

            category2.Id = Guid.NewGuid();
            category2.Title = "Categoria Nova";
            category2.Url = "categoria-nova";
            category2.Description = "Categoria nova";
            category2.Order = 9;
            category2.Summary = "Categoria";
            category2.Featured = true;

            var insertSql = @"INSERT INTO 
                                    Category 
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
                    category.Id,
                    category.Title,
                    category.Url,
                    category.Summary,
                    category.Order,
                    category.Description,
                    category.Featured
                },
                new
                {
                    category2.Id,
                    category2.Title,
                    category2.Url,
                    category2.Summary,
                    category2.Order,
                    category2.Description,
                    category2.Featured
                },
            });

            Console.WriteLine($"{rows} linhas inseridas");
        }
        static void ExecuteProcedure(SqlConnection connection)
        {
            var procedure = "[spDeleteStudent]";
            var pars = new { StudentID = "45b9fbaf-1d0c-4445-82fc-96cb0a68d824" };
            var affectedRows = connection.Execute(
                   procedure,
                   pars,
                   commandType: CommandType.StoredProcedure);
            Console.WriteLine($"{affectedRows} linhas afetadas");
        }

        static void ExecuteReadProcedure(SqlConnection connection)
        {
            var procedure = "[spGetCoursesByCategory]";
            var pars = new { CategoryId = "09ce0b7b-cfca-497b-92c0-3290ad9d5142" };
            var courses = connection.Query<Category>(
                   procedure,
                   pars,
                   commandType: CommandType.StoredProcedure);
            foreach (var item in courses)
            {
                Console.WriteLine(item.Id);
            }
        }

    }
}