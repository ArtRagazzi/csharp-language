using ProjetoFinal.SharedContext;
namespace ProjetoFinal.SubscriptionContext{
    public class Subscription : Base{
        public Plan plan {get;set}

        public DateTime? EndDate {get;set}
    
        public bool isInactive => EndDate <= DateTime.Now();
    }


}