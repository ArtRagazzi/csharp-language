using ProjetoFinal.NotificationContext;
using ProjetoFinal.SharedContext;
namespace ProjetoFinal.ContentContext;


public class CareerItem:Base{

    public CareerItem(int order, string title,string description, Course course){
        if(course == null){
            //throw new ArgumentNullException("O Curso não pode ser nullo");
            AddNotification(new Notification("Course", "Curso Invalido"));
        }
        this.Order = order;
        this.Title = title;
        this.Description = description;
        this.Course = course;
    }
    public int Order{ get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Course? Course{ get; set; }
        
}