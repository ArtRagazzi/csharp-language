using System;
using System.Collections;
using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog{
    class Program{
        
        private const string CONNECTION_STRING = @"Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True";
        
        static void Main(string[] args){
            
            /*InsertUser(new User("Joaquin Barbosa", 
                "joaquin@gmail.com",
                "HSSSS", 
                "Não gosto de Java",
                "https://foto.com",
                "joaquin-barbosa"));
            
            UpdateUser(new User(
                "Carlos Maciel",
                "carlinhos@gmail.com",
                "HASS", 
                "Não gosto de React",
                "https://foto.com", 
                "carlos-maciel"),2) ;
                
                DeleteUser(2);
            */
            
            
            foreach (var user in GetUsers()){
                Console.WriteLine(user);
            }
        }


        static List<User> GetUsers(){
            using (var connection = new SqlConnection(CONNECTION_STRING)){
                var users = connection.GetAll<User>();
                return users.ToList();
            }
        }

        static User GetUser(int id){
            using (var connection = new SqlConnection(CONNECTION_STRING)){
                var user = connection.Get<User>(id);
                return user;
            }
        }

        static void InsertUser(User user){
            using (var connection = new SqlConnection(CONNECTION_STRING)){
                connection.Insert(user);
            }
        }

        static void UpdateUser(User user, int id){

            user.Id = id; // Define o ID Corretamente antes de atualizar
            
            using (var connection = new SqlConnection(CONNECTION_STRING)){
                connection.Update(user);
            }
        }

        static void DeleteUser(int id){
            using (var connection = new SqlConnection(CONNECTION_STRING)){
                var user = connection.Get<User>(id);
                connection.Delete<User>(user);
            }
        }
    }
}

