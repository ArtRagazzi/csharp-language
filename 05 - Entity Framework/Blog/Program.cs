using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog
{
    class Program{
        static void Main(string[] args){
            using (var context = new BlogDataContext()){
                /* Insert
                var tag = new Tag{ Name = "ASP.NET", Slug = "aspnet" };
                context.Tags.Add(tag);
                */
                /*Update
                var tag = context.Tags.FirstOrDefault(x => x.Id == 1);
                tag.Name = ".NET";
                context.Update(tag);
                */
                /*Delete
                var tag = context.Tags.FirstOrDefault(x => x.Id == 1);
                context.Remove(tag);
                */
                /*ToList
                //ToList sempre no Final (USE ASNOTRACKING para consultas full, somente para Selects
                var tags = context
                    .Tags
                    .Where(x=> x.Name.Contains("Java"))
                    .ToList();
                foreach (var tag in tags){
                    Console.WriteLine($"{tag.Name}");
                }
                */
                var tag = context.Tags
                    .AsNoTracking()
                    .FirstOrDefault(x=>x.Id==3);

                Console.WriteLine($"{tag?.Name}");
                //Salva o que esta no Context (Memoria) No Banco
                context.SaveChanges();
            }
        }
    }
}