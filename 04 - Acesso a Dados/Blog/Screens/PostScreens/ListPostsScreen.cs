using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens;

public class ListPostsScreen{
    public static void Load(){
        Console.Clear();
        Console.WriteLine("Lista de Posts");
        Console.WriteLine("-------------");
        List();
        Console.ReadKey();
        MenuPostScreen.Load();
    }

    private static void List(){
        var repository = new Repository<Post>(Database.Connection);
        var posts = repository.GetAll();
        foreach (var post in posts){
            Console.WriteLine($"{post.Id} {post.Title} ~~{post.Body}~~ \n  - Ultima alteração: ({post.LastUpdateDate})");
        }
    }
}