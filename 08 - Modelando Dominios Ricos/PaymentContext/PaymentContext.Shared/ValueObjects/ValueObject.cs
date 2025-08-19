using Flunt.Notifications;

namespace PaymentContext.Shared.ValueObjects;

public class ValueObject
{
    private IList<string> Notifications;
    
    public ValueObject(){
        Notifications = new List<string>();

    }

    public void AddNotification(string message){
        Notifications.Add(message);
    }
    public IList<string> GetNotifications(){
        return Notifications;
    }
}
