using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens;

public class UpdateTagScreen{
    public static void Load(){
        Console.Clear();
        Console.WriteLine("Atualizar Tag");
        Console.WriteLine("-------------");
        Console.WriteLine();
        Console.WriteLine("Qual id da Tag que deseja alterar? ");
        var id = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Digite o novo nome da Tag");
        var nome = Console.ReadLine();
        Console.WriteLine("Digite o novo apelido da Tag");
        var apelido = Console.ReadLine();
        Atualizar(new Tag(nome, apelido), id);
        Console.ReadKey();
        MenuTagScreen.Load();
    }

    private static void Atualizar(Tag tag,int id){
        try{
            var repository = new Repository<Tag>(Database.Connection);
            repository.Update(tag,id);
            Console.WriteLine("Tag atualizada com sucesso!");
        }
        catch (Exception e){
            Console.WriteLine("Erro ao atualizar a tag");
            Console.WriteLine(e.Message);
        }
    }
}