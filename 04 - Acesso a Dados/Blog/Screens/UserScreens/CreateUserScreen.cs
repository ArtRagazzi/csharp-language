using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens;

public class CreateUserScreen{
    public static void Load(){
        Console.Clear();
        Console.WriteLine("Cadastrar Usuario");
        Console.WriteLine("-------------");
        Console.WriteLine();
        
        Console.WriteLine("Digite o Nome do Usuario");
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
        
        
        Cadastrar(new User(nome, email, hash, bio, url,apelido));
        Console.ReadKey();
        MenuUserScreen.Load();
    }

    private static void Cadastrar(User user){
        try{
            var repository = new UserRepository(Database.Connection);
            repository.Insert(user);
            Console.WriteLine("Usuario cadastrado(a) com sucesso!");
        }
        catch (Exception e){
            Console.WriteLine("Erro ao cadastrar a Usuario(a)");
            Console.WriteLine(e.Message);
        }
    }
}