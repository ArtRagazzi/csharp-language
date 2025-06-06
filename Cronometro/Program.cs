namespace Cronometro
{
    class Program
    {
        static void Main(string[] args){
            Console.WriteLine("Quantos segundos: ");
            int time = Convert.ToInt32(Console.ReadLine());
            Start(time);
        }

        static void Start(int secTime){
            int currentTime = 0;
            while (currentTime != secTime){
                Thread.Sleep(1000);
                Console.Clear();
                currentTime++;
                Console.WriteLine(currentTime);
                
            }
            Console.WriteLine("Acabou!");
        }
    }
}