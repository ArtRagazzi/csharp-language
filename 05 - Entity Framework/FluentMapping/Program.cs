using FluentMapping.Data;
using FluentMapping.Models;

namespace  FluentMapping;

public class Program{
    static void Main(string[] args){


        using (var context = new BlogDataContext()){
            context.Users.Add(new User{
                Bio = "Minha bio",
                Email = "meu Email",
                Image = "Imageee",
                Name = "Arutru",
                PasswordHash = "EASAE",
                Slug = "minha-bio",
            });

            context.SaveChanges();
        }
        
    }
}