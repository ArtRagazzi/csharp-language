using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens;

public class DeletePostScreen{
    public static void Load(){
        Console.Clear();
        Console.WriteLine("Excluir Post");
        Console.WriteLine("-------------");
        Console.WriteLine();
        Console.WriteLine("Qual id do Post que deseja excluir? ");
        var id = Int32.Parse(Console.ReadLine());
        Remover(id);
        Console.ReadKey();
        MenuPostScreen.Load();
    }

    private static void Remover(int id){
        try{
            var repository = new Repository<Post>(Database.Connection);
            repository.Delete(id);
            Console.WriteLine("Post excluido com sucesso!");
        }
        catch (Exception e){
            Console.WriteLine("Erro ao excluir o Post");
            Console.WriteLine(e.Message);
        }
    }
}