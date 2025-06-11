using ProjetoFinal.ContentContext;
using ProjetoFinal.ContentContext.Enums;

namespace ProjetoFinal
{
    class Program{
        static void Main(string[] args){
            Console.WriteLine("Hello World!");
            var course = new Course();
            course.Level = EContentLevel.ADVANCED;
            
            
        }
    }
}