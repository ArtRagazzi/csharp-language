using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens;

public class UpdateRoleScreen{
    public static void Load(){
        Console.Clear();
        Console.WriteLine("Atualizar Perfil");
        Console.WriteLine("-------------");
        Console.WriteLine();
        Console.WriteLine("Qual id do Perfil que deseja alterar? ");
        var id = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Digite o novo nome do Perfil");
        var nome = Console.ReadLine();
        Console.WriteLine("Digite o novo apelido do Perfil");
        var apelido = Console.ReadLine();
        Atualizar(new Role(nome, apelido), id);
        Console.ReadKey();
        MenuRoleScreen.Load();
    }

    private static void Atualizar(Role role,int id){
        try{
            var repository = new Repository<Role>(Database.Connection);
            repository.Update(role,id);
            Console.WriteLine("Perfil atualizado com sucesso!");
        }
        catch (Exception e){
            Console.WriteLine("Erro ao atualizar o perfil");
            Console.WriteLine(e.Message);
        }
    }
}