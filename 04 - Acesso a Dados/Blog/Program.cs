using System;
using System.Collections;
using Blog.Models;
using Blog.Repositories;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog{
    class Program{
        
        private const string CONNECTION_STRING = @"Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True";
        
        static void Main(string[] args){
            var connection = new SqlConnection(CONNECTION_STRING);
            connection.Open();
            var userRepository = new UserRepository(connection);
            var roleRepository = new Repository<Role>(connection);




            var users = userRepository.GetWithRoles();
            foreach (var user in users){
                Console.WriteLine(user);
                foreach (var role in user.Roles){
                    Console.WriteLine($" - {role.Name}");
                }
            }
            
            connection.Close();
            
        }


        
    }
}

