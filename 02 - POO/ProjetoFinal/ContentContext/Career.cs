namespace ProjetoFinal.ContentContext{
    
    
    public class Career : Content{

        public Career(string title, string url):base(title,url){
            this.Items = new List<CareerItem>();
        }
        public IList<CareerItem> Items{ get; set; }

        //QUando o atributo so tem um get(Expression Body)
        public int TotalCourses => Items.Count;
        //é o mesmo que
        //public int TotalCourses{
        //    get{
        //        return Items.Count;
        //    }
        //}

    }

    
}

