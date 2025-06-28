using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens;

public class CreateRoleScreen{
    public static void Load(){
        Console.Clear();
        Console.WriteLine("Cadastrar Perfil");
        Console.WriteLine("-------------");
        Console.WriteLine();
        Console.WriteLine("Digite o Nome da Perfil");
        var nome = Console.ReadLine();
        Console.WriteLine("Digite o Apelido do Perfil");
        var apelido = Console.ReadLine();
        Cadastrar(new Role(nome, apelido));
        Console.ReadKey();
        MenuRoleScreen.Load();
    }

    private static void Cadastrar(Role role){
        try{
            var repository = new Repository<Role>(Database.Connection);
            repository.Insert(role);
            Console.WriteLine("Perfil cadastrado com sucesso!");
        }
        catch (Exception e){
            Console.WriteLine("Erro ao cadastrar o perfil");
            Console.WriteLine(e.Message);
        }
    }
}