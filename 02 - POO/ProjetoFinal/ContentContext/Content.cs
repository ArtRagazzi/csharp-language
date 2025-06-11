namespace ProjetoFinal.ContentContext;

public abstract class Content{
    public Content(){
        this.Id = Guid.NewGuid();
    }
    public Guid Id{ get; set; }
    public string Title{ get; set; }
    public string Url{ get; set; }
}