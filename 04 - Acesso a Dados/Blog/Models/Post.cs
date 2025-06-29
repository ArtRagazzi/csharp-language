using Dapper.Contrib.Extensions;

namespace Blog.Models;

[Table("Post")]
public class Post:BaseModel{
    
    public string Title { get; set; }
    public string Summary { get; set; }
    public string Body { get; set; }
    public string Slug { get; set; }
    
    public int CategoryId { get; set; }
    public int AuthorId { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime LastUpdateDate { get; set; }

    public Post(){
        
    }

    public Post(string title, string summary, string body, string slug, int categoryId,int userId){
        this.Title = title;
        this.Summary = summary;
        this.Body = body;
        this.Slug = slug;
        this.CategoryId = categoryId;
        this.AuthorId = userId;
        this.CreateDate = DateTime.Now;
        this.LastUpdateDate = DateTime.Now;
    }
    
    public Post(string title, string summary, string body, string slug,int categoryId,int userId, DateTime createDate ,DateTime lastUpdateDate){
        this.Title = title;
        this.Summary = summary;
        this.Body = body;
        this.Slug = slug;
        this.CategoryId = categoryId;
        this.AuthorId = userId;
        this.CreateDate = createDate;
        this.LastUpdateDate = lastUpdateDate;
    }
    
}