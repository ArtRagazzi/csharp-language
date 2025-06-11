using ProjetoFinal.ContentContext;
using ProjetoFinal.ContentContext.Enums;

namespace ProjetoFinal
{
    class Program{
        static void Main(string[] args){
            
            var articles = new List<Article>();
            articles.Add(new Article("Artigo sobre OOP", "orientacao-objetos"));
            articles.Add(new Article("Artigo sobre Functional Programming","functional-programming"));

            foreach(var article in articles){
                Console.WriteLine(article.Id);
                Console.WriteLine(article.Title);
                Console.WriteLine(article.Url);
                Console.WriteLine("-------------");
            }

            var course1 = new Course("Fundamentos OOP", "fundamentos-oop");
            var course2 = new Course("Fundamentos C#", "fundamentos-csharp");
            var course3 = new Course("Fundamentos ASP.NET", "fundamentos-aspnet");

            var courses = new List<Course>();
            courses.Add(course1);
            courses.Add(course2);
            courses.Add(course3);

            var careers = new List<Career>(); 
            
            var career1 = new Career("Desenvolvedor .Net","desenvolvedor-dotnet");
            var career2 = new Career("Desenvolvedor C#","desenvolvedor-csharp");
            var career3 = new Career("Desenvolvedor ASPNET","desenvolvedor-aspnet");
            
            var careerItem1 = new CareerItem(3, "Começe por aqui...","",course1);
            var careerItem2 = new CareerItem(2, "Fundamentos","",course2);
            var careerItem3 = new CareerItem(1, "Avançando","",course3);
            career1.Items.Add(careerItem1);
            career1.Items.Add(careerItem3);
            career1.Items.Add(careerItem2);

            career2.Items.Add(careerItem1);
            career2.Items.Add(careerItem3);
            career2.Items.Add(careerItem2);

            career3.Items.Add(careerItem1);
            career3.Items.Add(careerItem3);
            career3.Items.Add(careerItem2);



            careers.Add(career1);
            careers.Add(career2);
            careers.Add(career3);



            foreach(var eachCareer in careers){
                Console.WriteLine(eachCareer.Title);
                foreach(var item in eachCareer.Items.OrderBy(x=>x.Order)){
                    Console.WriteLine($"{item.Order} - {item.Title} -> {item.Course.Title}");
                }
            }

            
        }
    }
}