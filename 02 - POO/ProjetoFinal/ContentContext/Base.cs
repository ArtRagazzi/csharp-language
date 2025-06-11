using ProjetoFinal.NotificationContext;

namespace ProjetoFinal.ContentContext{
    public class Base: Notifiable{

        public Base(){
            this.Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
    }
}