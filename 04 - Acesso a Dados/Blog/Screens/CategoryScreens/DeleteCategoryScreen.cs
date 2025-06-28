using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens;

public class DeleteCategoryScreen{
    public static void Load(){
        Console.Clear();
        Console.WriteLine("Excluir Categoria");
        Console.WriteLine("-------------");
        Console.WriteLine();
        Console.WriteLine("Qual id da Categoria que deseja excluir? ");
        var id = Int32.Parse(Console.ReadLine());
        Remover(id);
        Console.ReadKey();
        MenuCategoryScreen.Load();
    }

    private static void Remover(int id){
        try{
            var repository = new Repository<Category>(Database.Connection);
            repository.Delete(id);
            Console.WriteLine("Categoria excluida com sucesso!");
        }
        catch (Exception e){
            Console.WriteLine("Erro ao excluir a Categoria");
            Console.WriteLine(e.Message);
        }
    }
}