using Blog.Repositories;

namespace Blog.Screens.UserRoleScreens;

public class UnionUserRoleScreen{
    public static void Load(){
        Console.Clear();
        Console.WriteLine("Associar Perfil a Usuario");
        Console.WriteLine("-------------");
        Console.WriteLine();
        
        Console.WriteLine("Digite o Id do Usuario");
        var userId = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Digite o Id do Perfil");
        var roleId = Int32.Parse(Console.ReadLine());
        
        
        Associar(userId, roleId);
        Console.ReadKey();
        MenuUserRoleScreen.Load();
    }

    private static void Associar(int userId, int roleId){
        try{
            var repository = new UserRoleRepository(Database.Connection);
            repository.UnionUserRole(userId, roleId);
            Console.WriteLine("Associação criada com sucesso!");
        }
        catch (Exception e){
            Console.WriteLine("Erro ao realizar a Associação");
            Console.WriteLine(e.Message);
        }
    }
}