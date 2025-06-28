using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens;

public class DeleteRoleScreen{
    public static void Load(){
        Console.Clear();
        Console.WriteLine("Excluir Perfil");
        Console.WriteLine("-------------");
        Console.WriteLine();
        Console.WriteLine("Qual id do Perfil que deseja excluir? ");
        var id = Int32.Parse(Console.ReadLine());
        Remover(id);
        Console.ReadKey();
        MenuRoleScreen.Load();
    }

    private static void Remover(int id){
        try{
            var repository = new Repository<Role>(Database.Connection);
            repository.Delete(id);
            Console.WriteLine("Perfil excluido com sucesso!");
        }
        catch (Exception e){
            Console.WriteLine("Erro ao excluir o perfil");
            Console.WriteLine(e.Message);
        }
    }
}