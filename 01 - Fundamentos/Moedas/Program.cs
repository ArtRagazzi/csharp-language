using System.Globalization;

namespace Moeda
{
class Program{
    static void Main(string[] args){
        
        Console.Clear();
        decimal valor = 12520.25m;
        Console.WriteLine(valor);
        
        //Formatando Moedas
        
        Console.WriteLine(valor.ToString("C",CultureInfo.CreateSpecificCulture("en-US")));
        Console.WriteLine(valor.ToString("C",CultureInfo.CreateSpecificCulture("pt-BR")));
        Console.WriteLine(valor.ToString("C",CultureInfo.CreateSpecificCulture("pt-PT")));
        
    }
}
}