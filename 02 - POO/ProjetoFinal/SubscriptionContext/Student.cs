using ProjetoFinal.SharedContext;
namespace ProjetoFinal.SubscriptionContext{


    public class Student : Base{

        public Student(){
            this.Subscriptions = new List<Subscription>();
        }
        public string Name{ get; set; }
        public string Email{ get; set; }
        public User User{get;set;}

        public IList<Subscription> Subscriptions{ get; set; }

        public bool IsPremium => Subscriptions.Any(x=>!x.isInactive);

        public void CreateSubscription(Subscription subscription){
            if(IsPremium){
                AddNotification(new Notification("Premium", "Aluno ja é Premium"));
                return;
            }
            Subscriptions.Add(subscription);
        }

    }
}