using Dapper.Contrib.Extensions;

namespace Blog.Models;
[Table("Category")]

public class Category : BaseModel{
    public Category(){
        this.Posts = new List<Post>();
    }

    public Category(string name, string slug){
        this.Name = name;
        this.Slug = slug;
        this.Posts = new List<Post>();

    }
    public string Name{ get; set; }
    public string Slug{ get; set; }
    
    //Não utiliza o Posts no Insert
    [Write(false)]
    public List<Post> Posts{ get; set; }
}