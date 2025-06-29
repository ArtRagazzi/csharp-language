using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens;

public class CreatePostScreen{
    public static void Load(){
        Console.Clear();
        Console.WriteLine("Cadastrar Post");
        Console.WriteLine("-------------");
        Console.WriteLine();
        
        Console.WriteLine("Digite o Titulo do Post");
        var titulo = Console.ReadLine();
        Console.WriteLine("Digite o Sumario do Post");
        var sumario = Console.ReadLine();
        Console.WriteLine("Digite o Corpo do Post");
        var corpo = Console.ReadLine();
        Console.WriteLine("Digite o Apelido do Post");
        var apelido = Console.ReadLine();

        Console.WriteLine("Digite o Id da Categoria do Post");
        var categoria = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Digite o Id do Autor do Post");
        var autor = Int32.Parse(Console.ReadLine());

        
        Cadastrar(new Post(titulo,sumario,corpo,apelido,categoria,autor));
        Console.ReadKey();
        MenuPostScreen.Load();
    }

    private static void Cadastrar(Post post){
        try{
            var repository = new Repository<Post>(Database.Connection);
            repository.Insert(post);
            Console.WriteLine("Post cadastrada com sucesso!");
        }
        catch (Exception e){
            Console.WriteLine("Erro ao cadastrar o Post");
            Console.WriteLine(e.Message);
        }
    }
}