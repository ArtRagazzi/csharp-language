namespace AcessandoDados.Models;

public class Career{
    public Career(){
        this.Items = new List<CareerItem>();
    }
    
    public Guid Id{ get; set; }
    public string Title{ get; set; }
    public IList<CareerItem> Items{ get; set; }
}