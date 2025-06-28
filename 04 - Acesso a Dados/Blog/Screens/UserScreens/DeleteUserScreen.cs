using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens;

public class DeleteUserScreen{
    public static void Load(){
        Console.Clear();
        Console.WriteLine("Excluir Usuario");
        Console.WriteLine("-------------");
        Console.WriteLine();
        Console.WriteLine("Qual id do usuario(a) que deseja excluir? ");
        var id = Int32.Parse(Console.ReadLine());
        Remover(id);
        Console.ReadKey();
        MenuUserScreen.Load();
    }

    private static void Remover(int id){
        try{
            var repository = new UserRepository(Database.Connection);
            repository.Delete(id);
            Console.WriteLine("Usuario(a) excluida com sucesso!");
        }
        catch (Exception e){
            Console.WriteLine("Erro ao excluir o Usuario(a)");
            Console.WriteLine(e.Message);
        }
    }
}