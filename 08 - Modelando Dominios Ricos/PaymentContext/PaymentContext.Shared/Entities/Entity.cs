using Flunt.Notifications;

namespace PaymentContext.Shared.Entities;

public abstract class Entity
{
    private IList<string> Notifications;
    
    public Guid Id { get; private set; }

    public Entity(){
        Id = Guid.NewGuid();
        Notifications = new List<string>();
    }


    public void AddNotification(string message){
        Notifications.Add(message);
    }

    public IList<string> GetNotifications(){
        return Notifications;
    }
}
