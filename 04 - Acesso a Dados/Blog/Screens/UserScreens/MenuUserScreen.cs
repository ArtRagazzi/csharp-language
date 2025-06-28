namespace Blog.Screens.TagScreens;

public static class MenuUserScreen{
    public static void Load(){
        Console.Clear();
        Console.WriteLine("Gestão de Usuarios");
        Console.WriteLine("--------------");
        Console.WriteLine("O que deseja fazer?");
        Console.WriteLine();
        Console.WriteLine("1 - Listar Usuarios");
        Console.WriteLine("2 - Inserir Usuario");
        Console.WriteLine("3 - Atualizar Usuario");
        Console.WriteLine("4 - Excluir Usuario");
        Console.WriteLine();
        Console.WriteLine();
        var option = short.Parse(Console.ReadLine());


        switch (option){
            case 1:
                ListUsersScreen.Load();
                break;
            case 2:
                CreateUserScreen.Load();
                break;
            case 3:
                UpdateUserScreen.Load();
                break;
            case 4:
                DeleteUserScreen.Load();
                break;
            default: Load(); break;
        }
    }
}