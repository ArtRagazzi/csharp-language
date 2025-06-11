using ProjetoFinal.ContentContext.Enums;

namespace ProjetoFinal.ContentContext{

    public class Course : Content{
        public Course(){
            this.Modules = new List<Module>();
        }
        public string Tag{ get; set; }
        public int DurationInMinutes { get; set; }
        public IList<Module> Modules{ get; set; }
        public EContentLevel Level{ get; set; }
    }

    

}