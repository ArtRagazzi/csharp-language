namespace AcessandoDados.Models;

public class Category{
    public Guid Id{ get; set; }
    public string Title{ get; set; }
    public string Url{ get; set; }
    public int Order{ get; set; }
    public string Summary{ get; set; }
    public string Description{ get; set; }
    public bool Featured{ get; set; }

    public Category(string title, string url, int order, string summary, string description, bool featured){
        this.Id = Guid.NewGuid();
        this.Title = title;
        this.Url = url;
        this.Order = order;
        this.Summary = summary;
        this.Description = description;
        this.Featured = featured;
    }
    public Category(){}
}