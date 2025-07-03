using BlogMod2.Data;
using BlogMod2.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogMod2{
    public class Program{
        static void Main(string[] args){

            using (var context = new BlogDataContext()){
                
                // var user = new User{
                //     Name = "John Doe",
                //     Slug = "johndoe",
                //     Email = "jd@gmail.com",
                //     Bio = "Johnie Has a Doe",
                //     Image = "https://",
                //     PasswordHash = "ASDASDASD"
                // };
                // var category = new Category{
                //     Name = "Backend",
                //     Slug = "backend",
                // };
                //
                // var post = new Post{
                //     Author = user,
                //     Category = category,
                //     Body = "<p>Hello World</p>",
                //     Summary = "my-summary",
                //     Slug = "hello-world",
                //     Title = "Hello World",
                //     CreateDate = DateTime.Now,
                //     LastUpdateDate = DateTime.Now
                // };
                //
                // context.Posts.Add(post);
                // context.SaveChanges();
                
                // var posts = context.Posts
                //     .AsNoTracking()
                //     //Permite realizar o carregamento do Autor(USER)
                //     .Include(x=>x.Author)
                //     .Include(x=>x.Category)
                //     .OrderBy(x=> x.LastUpdateDate)
                //     .ToList();
                // foreach (var post in posts){
                //     Console.WriteLine($"{post.Title} escrito por {post.Author?.Name} em {post.Category?.Name}");
                // }

                var post = context.Posts
                    .Include(x => x.Author)
                    .Include(x => x.Category)
                    .OrderByDescending(x => x.LastUpdateDate)
                    .FirstOrDefault(); //Pegando primeiro Item

                post.Author.Name = "Teste";
                context.Posts.Update(post);
                
                context.SaveChanges();
            }
        }
    }
}

