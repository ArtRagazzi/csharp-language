using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens;

public class UpdateCategoryScreen{
    public static void Load(){
        Console.Clear();
        Console.WriteLine("Atualizar Categoria");
        Console.WriteLine("-------------");
        Console.WriteLine();
        Console.WriteLine("Qual id da Categoria que deseja alterar? ");
        var id = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Digite o novo nome da Categoria");
        var nome = Console.ReadLine();
        Console.WriteLine("Digite o novo apelido da Categoria");
        var apelido = Console.ReadLine();
        Atualizar(new Category(nome, apelido), id);
        Console.ReadKey();
        MenuCategoryScreen.Load();
    }

    private static void Atualizar(Category category,int id){
        try{
            var repository = new Repository<Category>(Database.Connection);
            repository.Update(category,id);
            Console.WriteLine("Categoria atualizada com sucesso!");
        }
        catch (Exception e){
            Console.WriteLine("Erro ao atualizar a Categoria");
            Console.WriteLine(e.Message);
        }
    }
}