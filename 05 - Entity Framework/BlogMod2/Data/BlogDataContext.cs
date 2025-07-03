using BlogMod2.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogMod2.Data;

public class BlogDataContext : DbContext{
    
    public DbSet<Post> Posts{ get; set; }
    public DbSet<User> Users{ get; set; }
    public DbSet<Category> Categories{ get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options){
        options.UseSqlServer("Server=localhost,1433;Database=Blog;User Id=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True");
        //Realiza o Log das query no Console
        //options.LogTo(Console.WriteLine);
    }
}