using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens;

public class CreateTagScreen{
    public static void Load(){
        Console.Clear();
        Console.WriteLine("Cadastrar Tag");
        Console.WriteLine("-------------");
        Console.WriteLine();
        Console.WriteLine("Digite o Nome da Tag");
        var nome = Console.ReadLine();
        Console.WriteLine("Digite o Apelido da Tag");
        var apelido = Console.ReadLine();
        Cadastrar(new Tag(nome, apelido));
        Console.ReadKey();
        MenuTagScreen.Load();
    }

    private static void Cadastrar(Tag tag){
        try{
            var repository = new Repository<Tag>(Database.Connection);
            repository.Insert(tag);
            Console.WriteLine("Tag cadastrada com sucesso!");
        }
        catch (Exception e){
            Console.WriteLine("Erro ao cadastrar a tag");
            Console.WriteLine(e.Message);
        }
    }
}