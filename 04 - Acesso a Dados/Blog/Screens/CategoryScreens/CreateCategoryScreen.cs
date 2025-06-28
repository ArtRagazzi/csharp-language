using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens;

public class CreateCategoryScreen{
    public static void Load(){
        Console.Clear();
        Console.WriteLine("Cadastrar Categoria");
        Console.WriteLine("-------------");
        Console.WriteLine();
        Console.WriteLine("Digite o Nome da Categoria");
        var nome = Console.ReadLine();
        Console.WriteLine("Digite o Apelido da Categoria");
        var apelido = Console.ReadLine();
        Cadastrar(new Category(nome, apelido));
        Console.ReadKey();
        MenuCategoryScreen.Load();
    }

    private static void Cadastrar(Category category){
        try{
            var repository = new Repository<Category>(Database.Connection);
            repository.Insert(category);
            Console.WriteLine("Categoria cadastrada com sucesso!");
        }
        catch (Exception e){
            Console.WriteLine("Erro ao cadastrar a Categoria");
            Console.WriteLine(e.Message);
        }
    }
}