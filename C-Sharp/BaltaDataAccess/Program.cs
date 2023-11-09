﻿using System;
using Microsoft.Data.SqlClient;

namespace BaltaDataAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = "Server=localhost,1433;Database=balta;User ID=SA;Password=1q2w3e4r@#$;TrustServerCertificate=True";
            // Microsoft.Data.SqlClient
            //Para baixar um pacote executar: dotnet add package Microsoft.Data.SqlClient
            /*var connection = new SqlConnection();
            connection.Open();

            connection.Close();
            connection.Dispose();*/
            using (var connection = new SqlConnection(connectionString))
            {
                Console.WriteLine("Conectado");
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "SELECT Id, Title FROM Category";

                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader.GetGuid(0)} - {reader.GetString(1)}");
                    }
                }
            }
            Console.WriteLine("Hello World!");
        }
    }
}