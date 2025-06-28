using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens;

public class UpdateUserScreen{
    public static void Load(){
        Console.Clear();
        Console.WriteLine("Atualizar Usuario");
        Console.WriteLine("-------------");
        Console.WriteLine();
        
        Console.WriteLine("Qual id do Usuario que deseja alterar? ");
        var id = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Digite o nome do Usuario");
        var nome = Console.ReadLine();
        Console.WriteLine("Digite o Email do Usuario");
        var email = Console.ReadLine();
        Console.WriteLine("Digite o Hash do Usuario");
        var hash = Console.ReadLine();
        Console.WriteLine("Digite a Bio do Usuario");
        var bio = Console.ReadLine();
        Console.WriteLine("Digite a URL de Imagem do Usuario");
        var url = Console.ReadLine();
        Console.WriteLine("Digite o apelido do Usuario");
        var apelido = Console.ReadLine();
        
        Atualizar(new User(nome,email,hash,bio,url,apelido), id);
        Console.ReadKey();
        MenuUserScreen.Load();
    }

    private static void Atualizar(User user,int id){
        try{
            var repository = new UserRepository(Database.Connection);
            repository.Update(user,id);
            Console.WriteLine("Usuario atualizado(a) com sucesso!");
        }
        catch (Exception e){
            Console.WriteLine("Erro ao atualizar o usuario(a)");
            Console.WriteLine(e.Message);
        }
    }
}