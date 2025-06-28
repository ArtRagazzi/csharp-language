using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens;

public class DeleteTagScreen{
    public static void Load(){
        Console.Clear();
        Console.WriteLine("Excluir Tag");
        Console.WriteLine("-------------");
        Console.WriteLine();
        Console.WriteLine("Qual id da Tag que deseja excluir? ");
        var id = Int32.Parse(Console.ReadLine());
        Remover(id);
        Console.ReadKey();
        MenuTagScreen.Load();
    }

    private static void Remover(int id){
        try{
            var repository = new Repository<Tag>(Database.Connection);
            repository.Delete(id);
            Console.WriteLine("Tag excluida com sucesso!");
        }
        catch (Exception e){
            Console.WriteLine("Erro ao excluir a tag");
            Console.WriteLine(e.Message);
        }
    }
}