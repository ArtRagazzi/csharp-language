using Dapper.Contrib.Extensions;

namespace Blog.Models;
[Table("Role")]
public class Role : BaseModel{
    public string Name { get; set; }
    public string Slug { get; set; }
    

    public Role(){
        
    }

    public Role(string name, string slug){
        this.Name = name;
        this.Slug = slug;
    }

    public override string ToString(){
        return $"{Name} - {Slug}";
    }
}