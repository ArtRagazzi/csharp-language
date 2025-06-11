namespace ProjetoFinal.ContentContext;

public class Module:Base{
    public Module(){
        this.Lectures = new List<Lecture>();
    }
    public int Order{ get; set; }
    public string Title{ get; set; }
    public IList<Lecture> Lectures{ get; set; }
}