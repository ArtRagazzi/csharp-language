using Dapper.Contrib.Extensions;

namespace Blog.Models;
[Table("Category")]

public class Category : BaseModel{
    public Category(){
        this.Posts = new List<Post>();
    }
    
    public string Name{ get; set; }
    public string Slug{ get; set; }
    public List<Post> Posts{ get; set; }
}