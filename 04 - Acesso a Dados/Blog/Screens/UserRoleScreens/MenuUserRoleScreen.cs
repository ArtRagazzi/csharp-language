namespace Blog.Screens.UserRoleScreens;

public class MenuUserRoleScreen{
    public static void Load(){
        Console.Clear();
        Console.WriteLine("Gestão de Usuario e Perfil");
        Console.WriteLine("--------------");
        Console.WriteLine("O que deseja fazer?");
        Console.WriteLine();
        Console.WriteLine("1 - Associar Perfil a Usuario");
        Console.WriteLine();
        Console.WriteLine();
        var option = short.Parse(Console.ReadLine());


        switch (option){
            case 1:
                UnionUserRoleScreen.Load();
                break;
            default: Load(); break;
        }
    }
}