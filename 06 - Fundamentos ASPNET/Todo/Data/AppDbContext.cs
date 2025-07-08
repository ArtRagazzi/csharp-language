using Microsoft.EntityFrameworkCore;
using Todo.Models;


namespace Todo.Data
{

    public class AppDbContext : DbContext{
        DbSet<TodoModel> Todos { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseSqlite("Datasource=app.db;Cache=Shared");
        }
        
        
        
    }

    

}