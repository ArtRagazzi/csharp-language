using ProjetoFinal.NotificationContext;

namespace ProjetoFinal.SharedContext{
    public class Base: Notifiable{

        public Base(){
            this.Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
    }
}