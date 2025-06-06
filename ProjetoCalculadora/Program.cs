using System;

namespace ProjetoCalculadora
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            int escolha = 0;
            
            do
            {
                Console.WriteLine("Qual opção deseja escolher: \n" +
                                               "1 - Somar\n" +
                                               "2 - Subtração\n" +
                                               "3 - Divisão\n" +
                                               "4 - Multiplicação\n" +
                                               "5 - Raiz Quadrada\n" +
                                               "0 - Sair");
                escolha = Convert.ToInt32(Console.ReadLine());
                if (escolha == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Digite o valor de x: ");
                    int x = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Digite o valor de y: ");
                    int y = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("A Soma de "+x+" e "+y+" é " +somar(x, y));
                }
                if (escolha == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Digite o valor de x: ");
                    int x = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Digite o valor de y: ");
                    int y = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("A Subtração de "+x+" e "+y+" é " +subtrair(x, y));
                }
                if (escolha == 3)
                {
                    Console.Clear();
                    Console.WriteLine("Digite o valor de x: ");
                    int x = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Digite o valor de y: ");
                    int y = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("A Divisão de "+x+" e "+y+" é " +divisao(x, y));
                }
                if (escolha == 4)
                {
                    Console.Clear();
                    Console.WriteLine("Digite o valor de x: ");
                    int x = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Digite o valor de y: ");
                    int y = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("A Multiplicação de "+x+" e "+y+" é " +multiplica(x, y));
                }
                if (escolha == 5)
                {
                    Console.Clear();
                    Console.WriteLine("Digite o valor de x: ");
                    int x = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("A Raiz Quadrada de "+x+" é " +raizQuadrada(x));
                }
            } while (escolha != 0);
        }
        
        static double somar(double x, double y)
        {
            return x + y;
        }

        static double subtrair(double x, double y)
        {
            return x - y;
        }

        static double multiplica(double x, double y)
        {
            return x * y;
        }

        static double divisao(double x, double y)
        {
            return x / y;
        }
ls
    
        static double raizQuadrada(double x)
        {
            return double.Sqrt(x);
        }
    }

    
}
