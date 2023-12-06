using Blog.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace BlogDataAccess
{
    public class Program
    {
        private const string CONNECTION_STRING = "Server=localhost,1433;Database=Blog;User ID=SA;Password=1q2w3e4r@#$;TrustServerCertificate=True";
        static void Main(string[] args)
        {
            //ReadUsers();
            //ReadUser();
            //CreateUser();
            //UpdateUser();
            DeleteUser();
        }

        public static void ReadUsers()
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var users = connection.GetAll<User>();

                foreach (var user in users)
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
                Name = "Equipe balta.io",
                Bio = "Equipe balta.io",
                Email = "hello@balta.io",
                Image = "https://.....",
                PasswordHash = "HASH",
                Slug = "equipe-balta"
            };

            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Insert<User>(user);
                Console.WriteLine("Cadastro realizado com sucesso");
            }
        }

        public static void UpdateUser()
        {
            var user = new User()
            {
                Id = 4,
                Name = "Equipe | balta.io",
                Bio = "Equipe de suporte balta.io",
                Email = "hello@balta.io",
                Image = "https://.....",
                PasswordHash = "HASH",
                Slug = "equipe-balta"
            };

            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Update<User>(user);
                Console.WriteLine("Atualização realizada com sucesso");
            }
        }

        public static void DeleteUser()
        {

            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var user = connection.Get<User>(4);
                connection.Delete<User>(user);
                Console.WriteLine("Usuário deletado com sucesso");
            }
        }
    }
}