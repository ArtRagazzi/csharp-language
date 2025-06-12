using ProjetoFinal.ContentContext.Enums;
using ProjetoFinal.SharedContext;

namespace ProjetoFinal.ContentContext;


public class Lecture:Base{
    public int Order{ get; set; }
    public string Title{ get; set; }
    public int DurationInMinutes { get; set; }
    public EContentLevel Level{ get; set; }
}