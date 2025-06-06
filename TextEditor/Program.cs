
namespace TextEditor{
    class Program{
        static void Main(string[] args){
            Menu();
        }

        static void Menu(){
            Console.Clear();
            Console.WriteLine("O que deseja fazer: ");
            Console.WriteLine("1 - Abrir arquivo");
            Console.WriteLine("2 - Criar novo arquivo");
            Console.WriteLine("0 - Sair");
            short option = short.Parse(Console.ReadLine());
            switch (option){
                case 0 : System.Environment.Exit(0);break;
                case 1: Abrir();break;
                case 2: Editar();break;
                default: Menu();break;
            }
        }

        static void Abrir(){
            Console.WriteLine("Qual o diretorio do arquivo: ");
            string path = Console.ReadLine();
            using (var file = new StreamReader(path)){
                string text = file.ReadToEnd();
                Console.WriteLine(text);
            }
            //Thread.Sleep(3000); melhor usar o Readline e esperar o usuario dar Enter
            Console.ReadLine();
            Menu();                                                                                                                                                                                                                                                                     
            
        }

        static void Editar(){
            Console.Clear();
            Console.WriteLine("Digite seu texto abaixo (ESC para sair)\n" +
                              "-----------------------------------------");
            string text = "";
            do{
                text += Console.ReadLine();
                text += Environment.NewLine;
            } while (Console.ReadKey().Key != ConsoleKey.F5);
            Salvar(text);
        }

        static void Salvar(string text){
            Console.Clear();
            const string path = "/home/artur/Documentos/meutexto.txt";
            //Using abre e fecha uma "sessao" igual fazer new StreamReader e no final StreamReader.close()
            using (var file = new StreamWriter(path)){
                file.Write(text);
            }
            Console.WriteLine($"Arquivo salvo em {path} com sucesso!");
            Thread.Sleep(2000);
            Menu();
        }
    }
}