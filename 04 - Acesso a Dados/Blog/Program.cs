using System;
using System.Collections;
using Blog.Models;
using Blog.Repositories;
using Blog.Screens.TagScreens;
using Blog.Screens.UserRoleScreens;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog{
    class Program{
        
        private const string CONNECTION_STRING = @"Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True";
        
        static void Main(string[] args){
            Database.Connection = new SqlConnection(CONNECTION_STRING);
            Database.Connection.Open();
            
            Load();
            
            
            Console.ReadKey();
            Database.Connection.Close();

        }

        public static void Load(){
            Console.Clear();
            Console.WriteLine("Meu blog");
            Console.WriteLine("--------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Gestão de Usuario");
            Console.WriteLine("2 - Gestão de Perfil");
            Console.WriteLine("3 - Gestão de Categorias");
            Console.WriteLine("4 - Gestão de Tags");
            Console.WriteLine("5 - Gestão de Posts");
            Console.WriteLine("6 - Vincular perfil/usuario");
            Console.WriteLine("7 - Vincular post/tag");
            Console.WriteLine();
            Console.WriteLine();
            var option = short.Parse(Console.ReadLine());


            switch (option){
                case 1:
                    MenuUserScreen.Load();
                    break;
                case 2:
                    MenuRoleScreen.Load();
                    break;
                case 3:
                    MenuCategoryScreen.Load();
                    break;
                case 4:
                    MenuTagScreen.Load();
                    break;
                case 5:
                    MenuPostScreen.Load();
                    break;
                case 6:
                    MenuUserRoleScreen.Load();
                    break;
                default: Load(); break;
            }
        }


        
    }
}

