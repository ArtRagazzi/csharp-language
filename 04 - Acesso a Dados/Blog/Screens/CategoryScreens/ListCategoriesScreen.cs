using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens;

public class ListCategoriesScreen{
    public static void Load(){
        Console.Clear();
        Console.WriteLine("Lista de Categorias");
        Console.WriteLine("-------------");
        List();
        Console.ReadKey();
        MenuCategoryScreen.Load();
    }

    private static void List(){
        var repository = new Repository<Category>(Database.Connection);
        var categories = repository.GetAll();
        foreach (var category in categories){
            Console.WriteLine($"{category.Id} {category.Name} ({category.Slug})\n - Quantidade de Posts: {category.Posts.Count}");
        }
    }
}