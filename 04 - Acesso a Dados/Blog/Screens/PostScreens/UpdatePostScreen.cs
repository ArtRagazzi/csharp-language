using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens;

public class UpdatePostScreen{
    public static void Load(){
        Console.Clear();
        Console.WriteLine("Atualizar Post");
        Console.WriteLine("-------------");
        Console.WriteLine();
        Console.WriteLine("Qual id do Post que deseja alterar? ");
        var id = Int32.Parse(Console.ReadLine());
        
        Console.WriteLine("Digite o Novo Titulo do Post");
        var titulo = Console.ReadLine();
        Console.WriteLine("Digite o Novo Sumario do Post");
        var sumario = Console.ReadLine();
        Console.WriteLine("Digite o Novo Corpo do Post");
        var corpo = Console.ReadLine();
        Console.WriteLine("Digite o Novo Apelido do Post");
        var apelido = Console.ReadLine();
        
        Console.WriteLine("Digite o Id da Categoria do Post");
        var categoria = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Digite o Id do Autor do Post");
        var autor = Int32.Parse(Console.ReadLine());
        
        //Feito dessa forma para que consiga manter o createDate igual o antigo (ANTES DE DAR UPDATE)
        Atualizar(titulo, sumario, corpo, apelido, categoria, autor, id);
        
        Console.ReadKey();
        MenuPostScreen.Load();
    }

    private static void Atualizar(string titulo, string sumario, string corpo, string apelido,int categoria, int autor,int id){
        try{
            var repository = new Repository<Post>(Database.Connection);
            //Gambiarra para manter o Createdate igual
            var post = new Post(titulo, sumario, corpo, apelido, categoria, autor, repository.Get(id).CreateDate,DateTime.Now);
            
            repository.Update(post,id);
            Console.WriteLine("Post atualizado com sucesso!");
        }
        catch (Exception e){
            Console.WriteLine("Erro ao atualizar o post");
            Console.WriteLine(e.Message);
        }
    }
}