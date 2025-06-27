using Dapper.Contrib.Extensions;

namespace Blog.Models;

[Table("Tag")]
public class Tag : BaseModel{
    
    public string Name{ get; set; }
    public string Slug{ get; set; }
}