using Dapper.Contrib.Extensions;

namespace Blog.Models;

[Table("Post")]
public class Post:BaseModel{
    
    public string Title { get; set; }
    public string Summary { get; set; }
    public string Body { get; set; }
    public string Slug { get; set; }
    public int CategoryId { get; set; }
    public int UserId { get; set; }
    public DateTime Created { get; set; }
    public DateTime LastUpdateDate { get; set; }
    
}