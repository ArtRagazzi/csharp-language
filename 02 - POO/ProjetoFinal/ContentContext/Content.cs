namespace ProjetoFinal.ContentContext;

public abstract class Content:Base{
    public Content(string title, string url){
        this.Title = title;
        this.Url = url;
    }
    public Guid Id{ get; set; }
    public string Title{ get; set; }
    public string Url{ get; set; }
}