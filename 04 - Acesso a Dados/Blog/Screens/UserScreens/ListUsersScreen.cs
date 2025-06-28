using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens;

public class ListUsersScreen{
    public static void Load(){
        Console.Clear();
        Console.WriteLine("Lista de Usuarios");
        Console.WriteLine("-------------");
        List();
        Console.ReadKey();
        MenuUserScreen.Load();
    }

    private static void List(){
        var repository = new UserRepository(Database.Connection);
        var users = repository.GetWithRoles();
        foreach (var user in users){
            Console.WriteLine($"{user.Name} : {user.Email} : {user.Slug}");
            foreach (var role in user.Roles){
                Console.WriteLine($" - {role.Name} : {role.Slug}");
            }
        }
    }
}